using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Lithium.Configuration.Data.Migrations
{
    public partial class InitialSchemaData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "configuration");

            migrationBuilder.CreateTable(
                name: "AppStagingAttributes",
                schema: "configuration",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    AttributeId = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppStagingAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppStagingContractTypes",
                schema: "configuration",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    EntityId = table.Column<string>(type: "text", nullable: true),
                    CategoryId = table.Column<string>(type: "text", nullable: true),
                    Feature = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppStagingContractTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractCategories",
                schema: "configuration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractStages",
                schema: "configuration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Stage = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractStages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataTypes",
                schema: "configuration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                schema: "configuration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ParentId = table.Column<int>(type: "integer", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Prefix = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                schema: "configuration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attributes",
                schema: "configuration",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    DataTypeId = table.Column<string>(type: "text", nullable: true),
                    HelpContent = table.Column<string>(type: "text", nullable: true),
                    IsGlobal = table.Column<bool>(type: "boolean", nullable: false),
                    IsMandatory = table.Column<bool>(type: "boolean", nullable: false),
                    IsForeign = table.Column<bool>(type: "boolean", nullable: false),
                    IsSearchable = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    UniqueIdentifier = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    LastStatusId = table.Column<int>(type: "integer", nullable: false),
                    StatusChangedBy = table.Column<string>(type: "text", nullable: true),
                    StatusChangedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attributes_Statuses_LastStatusId",
                        column: x => x.LastStatusId,
                        principalSchema: "configuration",
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attributes_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "configuration",
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractTypes",
                schema: "configuration",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    InstanceId = table.Column<string>(type: "text", nullable: true),
                    CategoryId = table.Column<string>(type: "text", nullable: true),
                    FeatureId = table.Column<string>(type: "text", nullable: true),
                    IsLatest = table.Column<bool>(type: "boolean", nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PublishedBy = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    UniqueIdentifier = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    LastStatusId = table.Column<int>(type: "integer", nullable: false),
                    StatusChangedBy = table.Column<string>(type: "text", nullable: true),
                    StatusChangedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractTypes_Statuses_LastStatusId",
                        column: x => x.LastStatusId,
                        principalSchema: "configuration",
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractTypes_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "configuration",
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractTypeAttributes",
                schema: "configuration",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    AttributeId = table.Column<string>(type: "text", nullable: true),
                    ContractTypeId = table.Column<string>(type: "text", nullable: true),
                    InstanceId = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    UniqueIdentifier = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    LastStatusId = table.Column<int>(type: "integer", nullable: false),
                    StatusChangedBy = table.Column<string>(type: "text", nullable: true),
                    StatusChangedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractTypeAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractTypeAttributes_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalSchema: "configuration",
                        principalTable: "Attributes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractTypeAttributes_ContractTypes_ContractTypeId",
                        column: x => x.ContractTypeId,
                        principalSchema: "configuration",
                        principalTable: "ContractTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractTypeAttributes_Statuses_LastStatusId",
                        column: x => x.LastStatusId,
                        principalSchema: "configuration",
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractTypeAttributes_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "configuration",
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_LastStatusId",
                schema: "configuration",
                table: "Attributes",
                column: "LastStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_StatusId",
                schema: "configuration",
                table: "Attributes",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTypeAttributes_AttributeId",
                schema: "configuration",
                table: "ContractTypeAttributes",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTypeAttributes_ContractTypeId",
                schema: "configuration",
                table: "ContractTypeAttributes",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTypeAttributes_LastStatusId",
                schema: "configuration",
                table: "ContractTypeAttributes",
                column: "LastStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTypeAttributes_StatusId",
                schema: "configuration",
                table: "ContractTypeAttributes",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTypes_LastStatusId",
                schema: "configuration",
                table: "ContractTypes",
                column: "LastStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTypes_StatusId",
                schema: "configuration",
                table: "ContractTypes",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppStagingAttributes",
                schema: "configuration");

            migrationBuilder.DropTable(
                name: "AppStagingContractTypes",
                schema: "configuration");

            migrationBuilder.DropTable(
                name: "ContractCategories",
                schema: "configuration");

            migrationBuilder.DropTable(
                name: "ContractStages",
                schema: "configuration");

            migrationBuilder.DropTable(
                name: "ContractTypeAttributes",
                schema: "configuration");

            migrationBuilder.DropTable(
                name: "DataTypes",
                schema: "configuration");

            migrationBuilder.DropTable(
                name: "Features",
                schema: "configuration");

            migrationBuilder.DropTable(
                name: "Attributes",
                schema: "configuration");

            migrationBuilder.DropTable(
                name: "ContractTypes",
                schema: "configuration");

            migrationBuilder.DropTable(
                name: "Statuses",
                schema: "configuration");
        }
    }
}
