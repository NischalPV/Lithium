using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lithium.Identity.Data.Migrations.ConfigurationDb
{
    public partial class SchemaUpdateSchema2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "identity");

            migrationBuilder.RenameTable(
                name: "IdentityResources",
                newName: "IdentityResources",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "IdentityResourceProperties",
                newName: "IdentityResourceProperties",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "IdentityResourceClaims",
                newName: "IdentityResourceClaims",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "ClientSecrets",
                newName: "ClientSecrets",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "ClientScopes",
                newName: "ClientScopes",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Clients",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "ClientRedirectUris",
                newName: "ClientRedirectUris",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "ClientProperties",
                newName: "ClientProperties",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "ClientPostLogoutRedirectUris",
                newName: "ClientPostLogoutRedirectUris",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "ClientIdPRestrictions",
                newName: "ClientIdPRestrictions",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "ClientGrantTypes",
                newName: "ClientGrantTypes",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "ClientCorsOrigins",
                newName: "ClientCorsOrigins",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "ClientClaims",
                newName: "ClientClaims",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "ApiScopes",
                newName: "ApiScopes",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "ApiScopeProperties",
                newName: "ApiScopeProperties",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "ApiScopeClaims",
                newName: "ApiScopeClaims",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "ApiResourceSecrets",
                newName: "ApiResourceSecrets",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "ApiResourceScopes",
                newName: "ApiResourceScopes",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "ApiResources",
                newName: "ApiResources",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "ApiResourceProperties",
                newName: "ApiResourceProperties",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "ApiResourceClaims",
                newName: "ApiResourceClaims",
                newSchema: "identity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "IdentityResources",
                schema: "identity",
                newName: "IdentityResources");

            migrationBuilder.RenameTable(
                name: "IdentityResourceProperties",
                schema: "identity",
                newName: "IdentityResourceProperties");

            migrationBuilder.RenameTable(
                name: "IdentityResourceClaims",
                schema: "identity",
                newName: "IdentityResourceClaims");

            migrationBuilder.RenameTable(
                name: "ClientSecrets",
                schema: "identity",
                newName: "ClientSecrets");

            migrationBuilder.RenameTable(
                name: "ClientScopes",
                schema: "identity",
                newName: "ClientScopes");

            migrationBuilder.RenameTable(
                name: "Clients",
                schema: "identity",
                newName: "Clients");

            migrationBuilder.RenameTable(
                name: "ClientRedirectUris",
                schema: "identity",
                newName: "ClientRedirectUris");

            migrationBuilder.RenameTable(
                name: "ClientProperties",
                schema: "identity",
                newName: "ClientProperties");

            migrationBuilder.RenameTable(
                name: "ClientPostLogoutRedirectUris",
                schema: "identity",
                newName: "ClientPostLogoutRedirectUris");

            migrationBuilder.RenameTable(
                name: "ClientIdPRestrictions",
                schema: "identity",
                newName: "ClientIdPRestrictions");

            migrationBuilder.RenameTable(
                name: "ClientGrantTypes",
                schema: "identity",
                newName: "ClientGrantTypes");

            migrationBuilder.RenameTable(
                name: "ClientCorsOrigins",
                schema: "identity",
                newName: "ClientCorsOrigins");

            migrationBuilder.RenameTable(
                name: "ClientClaims",
                schema: "identity",
                newName: "ClientClaims");

            migrationBuilder.RenameTable(
                name: "ApiScopes",
                schema: "identity",
                newName: "ApiScopes");

            migrationBuilder.RenameTable(
                name: "ApiScopeProperties",
                schema: "identity",
                newName: "ApiScopeProperties");

            migrationBuilder.RenameTable(
                name: "ApiScopeClaims",
                schema: "identity",
                newName: "ApiScopeClaims");

            migrationBuilder.RenameTable(
                name: "ApiResourceSecrets",
                schema: "identity",
                newName: "ApiResourceSecrets");

            migrationBuilder.RenameTable(
                name: "ApiResourceScopes",
                schema: "identity",
                newName: "ApiResourceScopes");

            migrationBuilder.RenameTable(
                name: "ApiResources",
                schema: "identity",
                newName: "ApiResources");

            migrationBuilder.RenameTable(
                name: "ApiResourceProperties",
                schema: "identity",
                newName: "ApiResourceProperties");

            migrationBuilder.RenameTable(
                name: "ApiResourceClaims",
                schema: "identity",
                newName: "ApiResourceClaims");
        }
    }
}
