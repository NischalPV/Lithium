using System;
using System.Security.Cryptography.X509Certificates;

namespace Lithium.Identity;

public class Certificate
{
    public static X509Certificate2 Get(string certName)
    {
        var assembly = typeof(Certificate).GetTypeInfo().Assembly;
        var resourceName = $"{assembly.GetName().Name}.Certificates.{certName}.pfx";

        using (var stream = assembly.GetManifestResourceStream(resourceName))
        {
            if (stream == null)
            {
                throw new FileNotFoundException("Resource not found");
            }

            return new X509Certificate2(ReadStream(stream), "learning@2022");
        }
    }

    // ReadStream method to read Stream input and return byte array
    private static byte[] ReadStream(Stream input)
    {
        byte[] buffer = new byte[16 * 1024];
        using (MemoryStream ms = new MemoryStream())
        {
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                ms.Write(buffer, 0, read);
            }
            return ms.ToArray();
        }
    }
}

