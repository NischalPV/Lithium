using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iManage.Migrations
{
    public partial class clientData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Name", "Occupation", "Phone" },
                values: new object[] { "ad9809f2-3049-48d9-ba0a-3500945c3807", new DateTime(2019, 4, 19, 0, 19, 0, 0, DateTimeKind.Local), null, "Nischal Varasada", "Invert Triangle", "+91 84699 40719" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Name", "Occupation", "Phone" },
                values: new object[] { "4e24aeab-31ca-4ff5-a1fd-82a0faa22593", new DateTime(2019, 4, 19, 0, 19, 0, 0, DateTimeKind.Local), null, "Rishi Varasada", "Invert Triangle", "+91 84699 40719" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Name", "Occupation", "Phone" },
                values: new object[] { "d59fe783-c6fd-4d3f-aa77-9b505dc37f93", new DateTime(2019, 4, 19, 0, 19, 0, 0, DateTimeKind.Local), null, "Payal Varasada", "Invert Triangle", "+91 84699 40719" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "4e24aeab-31ca-4ff5-a1fd-82a0faa22593");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "ad9809f2-3049-48d9-ba0a-3500945c3807");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "d59fe783-c6fd-4d3f-aa77-9b505dc37f93");
        }
    }
}
