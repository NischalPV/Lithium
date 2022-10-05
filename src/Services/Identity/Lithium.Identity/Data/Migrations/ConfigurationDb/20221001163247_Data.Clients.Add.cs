using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lithium.Identity.Data.Migrations.ConfigurationDb
{
    public partial class DataClientsAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "identity",
                table: "ApiResources",
                columns: new[] { "Id", "AllowedAccessTokenSigningAlgorithms", "Created", "Description", "DisplayName", "Enabled", "LastAccessed", "Name", "NonEditable", "ShowInDiscoveryDocument", "Updated" },
                values: new object[] { 2, null, new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Configuration API Service", true, null, "ConfigurationAPI", false, true, null });

            migrationBuilder.InsertData(
                schema: "identity",
                table: "ApiScopes",
                columns: new[] { "Id", "Description", "DisplayName", "Emphasize", "Enabled", "Name", "Required", "ShowInDiscoveryDocument" },
                values: new object[] { 2, null, "Configuration API Scope", false, true, "ConfigurationAPI", false, true });

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "ClientPostLogoutRedirectUris",
                keyColumn: "Id",
                keyValue: 3,
                column: "PostLogoutRedirectUri",
                value: "https://lithium-web.azurewebsites.net/");

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "ClientPostLogoutRedirectUris",
                keyColumn: "Id",
                keyValue: 4,
                column: "PostLogoutRedirectUri",
                value: "https://lithium-api.azurewebsites.net/swagger/");

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "ClientRedirectUris",
                keyColumn: "Id",
                keyValue: 3,
                column: "RedirectUri",
                value: "https://lithium-web.azurewebsites.net/");

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "ClientRedirectUris",
                keyColumn: "Id",
                keyValue: 4,
                column: "RedirectUri",
                value: "https://lithium-api.azurewebsites.net/swagger/oauth2-redirect.html");

            migrationBuilder.InsertData(
                schema: "identity",
                table: "ClientScopes",
                columns: new[] { "Id", "ClientId", "Scope" },
                values: new object[,]
                {
                    { 9, 1, "ConfigurationAPI" },
                    { 10, 2, "ConfigurationAPI" },
                    { 11, 3, "ConfigurationAPI" },
                    { 12, 4, "ConfigurationAPI" }
                });

            migrationBuilder.InsertData(
                schema: "identity",
                table: "Clients",
                columns: new[] { "Id", "AbsoluteRefreshTokenLifetime", "AccessTokenLifetime", "AccessTokenType", "AllowAccessTokensViaBrowser", "AllowOfflineAccess", "AllowPlainTextPkce", "AllowRememberConsent", "AllowedIdentityTokenSigningAlgorithms", "AlwaysIncludeUserClaimsInIdToken", "AlwaysSendClientClaims", "AuthorizationCodeLifetime", "BackChannelLogoutSessionRequired", "BackChannelLogoutUri", "ClientClaimsPrefix", "ClientId", "ClientName", "ClientUri", "ConsentLifetime", "Created", "Description", "DeviceCodeLifetime", "EnableLocalLogin", "Enabled", "FrontChannelLogoutSessionRequired", "FrontChannelLogoutUri", "IdentityTokenLifetime", "IncludeJwtId", "LastAccessed", "LogoUri", "NonEditable", "PairWiseSubjectSalt", "ProtocolType", "RefreshTokenExpiration", "RefreshTokenUsage", "RequireClientSecret", "RequireConsent", "RequirePkce", "RequireRequestObject", "SlidingRefreshTokenLifetime", "UpdateAccessTokenClaimsOnRefresh", "Updated", "UserCodeType", "UserSsoLifetime" },
                values: new object[,]
                {
                    { 5, 2592000, 3600, 0, true, false, false, true, null, false, false, 300, true, null, "client_", "lithium-configuration-api", "Lithium Configuration API Swagger UI", null, null, new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Lithium Configuration API Swagger UI for Development", 300, true, true, true, null, 300, true, null, null, false, null, "oidc", 1, 1, true, false, true, false, 1296000, false, null, null, null },
                    { 6, 2592000, 3600, 0, true, false, false, true, null, false, false, 300, true, null, "client_", "lithium-configuration-api--prod", "Lithium Configuration API Swagger UI", null, null, new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Lithium Configuration API Swagger UI for Production", 300, true, true, true, null, 300, true, null, null, false, null, "oidc", 1, 1, true, false, true, false, 1296000, false, null, null, null }
                });

            migrationBuilder.InsertData(
                schema: "identity",
                table: "ApiResourceScopes",
                columns: new[] { "Id", "ApiResourceId", "Scope" },
                values: new object[] { 2, 2, "ConfigurationAPI" });

            migrationBuilder.InsertData(
                schema: "identity",
                table: "ClientPostLogoutRedirectUris",
                columns: new[] { "Id", "ClientId", "PostLogoutRedirectUri" },
                values: new object[,]
                {
                    { 5, 5, "http://localhost:6006/swagger/" },
                    { 6, 6, "https://lithium-configuration.azurewebsites.net/swagger/" }
                });

            migrationBuilder.InsertData(
                schema: "identity",
                table: "ClientRedirectUris",
                columns: new[] { "Id", "ClientId", "RedirectUri" },
                values: new object[,]
                {
                    { 5, 5, "http://localhost:6006/swagger/oauth2-redirect.html" },
                    { 6, 6, "https://lithium-configuration.azurewebsites.net/swagger/oauth2-redirect.html" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "identity",
                table: "ApiResourceScopes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "ClientPostLogoutRedirectUris",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "ClientPostLogoutRedirectUris",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "ClientRedirectUris",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "ClientRedirectUris",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "ClientScopes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "ClientScopes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "ClientScopes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "ClientScopes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "ApiResources",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "Clients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "ClientPostLogoutRedirectUris",
                keyColumn: "Id",
                keyValue: 3,
                column: "PostLogoutRedirectUri",
                value: "https://lithium.web.azurewebsites.net/");

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "ClientPostLogoutRedirectUris",
                keyColumn: "Id",
                keyValue: 4,
                column: "PostLogoutRedirectUri",
                value: "https://lithium.api.azurewebsites.net/swagger/");

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "ClientRedirectUris",
                keyColumn: "Id",
                keyValue: 3,
                column: "RedirectUri",
                value: "https://lithium.web.azurewebsites.net/");

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "ClientRedirectUris",
                keyColumn: "Id",
                keyValue: 4,
                column: "RedirectUri",
                value: "https://lithium.api.azurewebsites.net/swagger/oauth2-redirect.html");
        }
    }
}
