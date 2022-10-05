using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lithium.Configuration.Data.Migrations
{
    public partial class InitialDefaultData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "configuration",
                table: "ContractCategories",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "Agreement" },
                    { 2, true, "Annexure" },
                    { 3, true, "Masterdata" },
                    { 4, true, "Contract Request" }
                });

            migrationBuilder.InsertData(
                schema: "configuration",
                table: "ContractStages",
                columns: new[] { "Id", "IsActive", "Stage" },
                values: new object[,]
                {
                    { 1, true, "Template Authoring" },
                    { 2, true, "Contract Creation" },
                    { 3, true, "Contract Review" },
                    { 4, true, "Contract Approval" },
                    { 5, true, "Contract Execution" },
                    { 6, true, "Contract Performance" },
                    { 7, true, "Contract Expiry" }
                });

            migrationBuilder.InsertData(
                schema: "configuration",
                table: "DataTypes",
                columns: new[] { "Id", "Description", "IsActive", "Type" },
                values: new object[,]
                {
                    { 1, "Plain text", true, "string" },
                    { 2, "Whole numbers from -2^31 (-2,147,483,648) to 2^31-1 (2,147,483,647)", true, "integer" },
                    { 3, "24 digit decimal number with 6 decimal places", true, "decimal" },
                    { 4, "Simple Yes/No", true, "boolean" },
                    { 5, "User input through either drop down or Radio buttons or Checkboxes", true, "choice" },
                    { 6, "Currency inputs", true, "currency" },
                    { 7, "Date input", true, "date" },
                    { 8, "Textbox to allow user to input email", true, "email" },
                    { 9, "0-100% with 4 decimal places", true, "percent" },
                    { 10, "Textbox to allow user to input url", true, "url" },
                    { 11, "Formula input to perform simple calculations", true, "computed" }
                });

            migrationBuilder.InsertData(
                schema: "configuration",
                table: "Statuses",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "Draft" },
                    { 2, true, "Waiting for Approval" },
                    { 3, true, "Approved" },
                    { 4, true, "Published" },
                    { 5, true, "Executed" },
                    { 6, true, "Expired" },
                    { 7, true, "Renewed" },
                    { 8, true, "Terminated" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "configuration",
                table: "ContractCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "configuration",
                table: "ContractCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "configuration",
                table: "ContractCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "configuration",
                table: "ContractCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "configuration",
                table: "ContractStages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "configuration",
                table: "ContractStages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "configuration",
                table: "ContractStages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "configuration",
                table: "ContractStages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "configuration",
                table: "ContractStages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "configuration",
                table: "ContractStages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "configuration",
                table: "ContractStages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "configuration",
                table: "DataTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "configuration",
                table: "DataTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "configuration",
                table: "DataTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "configuration",
                table: "DataTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "configuration",
                table: "DataTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "configuration",
                table: "DataTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "configuration",
                table: "DataTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "configuration",
                table: "DataTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "configuration",
                table: "DataTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "configuration",
                table: "DataTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "configuration",
                table: "DataTypes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "configuration",
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "configuration",
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "configuration",
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "configuration",
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "configuration",
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "configuration",
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "configuration",
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "configuration",
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
