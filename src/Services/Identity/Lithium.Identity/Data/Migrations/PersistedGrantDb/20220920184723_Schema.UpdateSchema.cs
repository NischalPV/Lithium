using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lithium.Identity.Data.Migrations.PersistedGrantDb
{
    public partial class SchemaUpdateSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "identity");

            migrationBuilder.RenameTable(
                name: "PersistedGrants",
                newName: "PersistedGrants",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "DeviceCodes",
                newName: "DeviceCodes",
                newSchema: "identity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "PersistedGrants",
                schema: "identity",
                newName: "PersistedGrants");

            migrationBuilder.RenameTable(
                name: "DeviceCodes",
                schema: "identity",
                newName: "DeviceCodes");
        }
    }
}
