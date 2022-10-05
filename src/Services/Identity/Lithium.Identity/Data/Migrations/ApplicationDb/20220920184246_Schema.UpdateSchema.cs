using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lithium.Identity.Data.Migrations.ApplicationDb
{
    public partial class SchemaUpdateSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "identity");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "AspNetUserTokens",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "AspNetUsers",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "AspNetUserRoles",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "AspNetUserLogins",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "AspNetUserClaims",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "AspNetRoles",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "AspNetRoleClaims",
                newSchema: "identity");

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01ce8033-ff7b-49d4-b948-d024771649b9",
                column: "ConcurrencyStamp",
                value: "ef770293-917e-46a8-a0a4-d5458e1c2539");

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "117dc0ff-4d12-4a15-8c6b-77e9b903cd63",
                column: "ConcurrencyStamp",
                value: "faca569d-a69e-437e-a37b-035035476ce4");

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0aab6ba-cd71-4010-a9dc-e246997d6183",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEIt3OUoLEV+Tz06U56r55yri4ggawg9Wa0bn8Tm8mZR1zsTzxdGVW7W71YYHiRy8Fg==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "identity",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "identity",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "identity",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "identity",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "identity",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "identity",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "identity",
                newName: "AspNetRoleClaims");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01ce8033-ff7b-49d4-b948-d024771649b9",
                column: "ConcurrencyStamp",
                value: "5057be8f-96ae-40ab-bd0b-014d0c506013");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "117dc0ff-4d12-4a15-8c6b-77e9b903cd63",
                column: "ConcurrencyStamp",
                value: "9f4d5ecd-1856-47f1-a5e6-2d5f35d104ca");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0aab6ba-cd71-4010-a9dc-e246997d6183",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEGlCduZqJ3oE5uIdQ8oqt6XVQ/Ahnk8GlNWw41/nJBipVUEHVKBEpD6oNWAB/L3kKw==");
        }
    }
}
