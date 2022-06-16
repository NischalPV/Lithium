namespace Lithium.Identity.Devspaces;

static class IdentityDevspacesBuilderExtensions
{
    public static IIdentityServerBuilder AddDevspacesIfNeeded(this IIdentityServerBuilder builder, bool useDevspaces)
    {
        if (useDevspaces)
        {
            builder.AddRedirectUriValidator<DevspacesRedirectUriValidator>();
        }

        return builder;
    }
}

