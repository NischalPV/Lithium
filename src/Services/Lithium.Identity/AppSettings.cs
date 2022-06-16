using System;
namespace Lithium.Identity
{
	public class AppSettings
	{
        public string IsClusterEnv { get; set; }
        public string WebApiUrl { get; set; }
        public string AngularUrl { get; set; }
        public string SigningCertificate { get; set; }
        public int UseCustomizationData { get; set; }
    }
}

