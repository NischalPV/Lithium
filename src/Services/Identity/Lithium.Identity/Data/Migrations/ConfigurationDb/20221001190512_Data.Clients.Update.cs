using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lithium.Identity.Data.Migrations.ConfigurationDb
{
    public partial class DataClientsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "identity",
                table: "ClientGrantTypes",
                columns: new[] { "Id", "ClientId", "GrantType" },
                values: new object[,]
                {
                    { 5, 5, "implicit" },
                    { 6, 6, "implicit" }
                });

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "ClientPostLogoutRedirectUris",
                keyColumn: "Id",
                keyValue: 5,
                column: "PostLogoutRedirectUri",
                value: "http://localhost:38780/swagger/");

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "ClientRedirectUris",
                keyColumn: "Id",
                keyValue: 5,
                column: "RedirectUri",
                value: "http://localhost:38780/swagger/oauth2-redirect.html");

            migrationBuilder.InsertData(
                schema: "identity",
                table: "ClientScopes",
                columns: new[] { "Id", "ClientId", "Scope" },
                values: new object[,]
                {
                    { 13, 5, "ConfigurationAPI" },
                    { 14, 6, "ConfigurationAPI" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "identity",
                table: "ClientGrantTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "ClientGrantTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "ClientScopes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "ClientScopes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "ClientPostLogoutRedirectUris",
                keyColumn: "Id",
                keyValue: 5,
                column: "PostLogoutRedirectUri",
                value: "http://localhost:6006/swagger/");

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "ClientRedirectUris",
                keyColumn: "Id",
                keyValue: 5,
                column: "RedirectUri",
                value: "http://localhost:6006/swagger/oauth2-redirect.html");
        }
    }
}
