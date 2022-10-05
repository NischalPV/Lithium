﻿// <auto-generated />
using System;
using Lithium.Configuration.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Lithium.Configuration.Data.Migrations
{
    [DbContext(typeof(LithiumConfigurationDbContext))]
    [Migration("20221002133112_Schema.Removed.AppStaging")]
    partial class SchemaRemovedAppStaging
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("configuration")
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Lithium.BaseEntities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Statuses", "configuration");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            Name = "Draft"
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            Name = "Waiting for Approval"
                        },
                        new
                        {
                            Id = 3,
                            IsActive = true,
                            Name = "Approved"
                        },
                        new
                        {
                            Id = 4,
                            IsActive = true,
                            Name = "Published"
                        },
                        new
                        {
                            Id = 5,
                            IsActive = true,
                            Name = "Executed"
                        },
                        new
                        {
                            Id = 6,
                            IsActive = true,
                            Name = "Expired"
                        },
                        new
                        {
                            Id = 7,
                            IsActive = true,
                            Name = "Renewed"
                        },
                        new
                        {
                            Id = 8,
                            IsActive = true,
                            Name = "Terminated"
                        });
                });

            modelBuilder.Entity("Lithium.Configuration.Core.Elements.Attribute", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DataTypeId")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("HelpContent")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsForeign")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsGlobal")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsMandatory")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsSearchable")
                        .HasColumnType("boolean");

                    b.Property<int>("LastStatusId")
                        .HasColumnType("integer");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("StatusChangedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("StatusChangedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<string>("UniqueIdentifier")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LastStatusId");

                    b.HasIndex("StatusId");

                    b.ToTable("Attributes", "configuration");
                });

            modelBuilder.Entity("Lithium.Configuration.Core.Elements.ContractCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ContractCategories", "configuration");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            Name = "Agreement"
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            Name = "Annexure"
                        },
                        new
                        {
                            Id = 3,
                            IsActive = true,
                            Name = "Masterdata"
                        },
                        new
                        {
                            Id = 4,
                            IsActive = true,
                            Name = "Contract Request"
                        });
                });

            modelBuilder.Entity("Lithium.Configuration.Core.Elements.ContractStage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Stage")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ContractStages", "configuration");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            Stage = "Template Authoring"
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            Stage = "Contract Creation"
                        },
                        new
                        {
                            Id = 3,
                            IsActive = true,
                            Stage = "Contract Review"
                        },
                        new
                        {
                            Id = 4,
                            IsActive = true,
                            Stage = "Contract Approval"
                        },
                        new
                        {
                            Id = 5,
                            IsActive = true,
                            Stage = "Contract Execution"
                        },
                        new
                        {
                            Id = 6,
                            IsActive = true,
                            Stage = "Contract Performance"
                        },
                        new
                        {
                            Id = 7,
                            IsActive = true,
                            Stage = "Contract Expiry"
                        });
                });

            modelBuilder.Entity("Lithium.Configuration.Core.Elements.ContractType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("CategoryId")
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("FeatureId")
                        .HasColumnType("text");

                    b.Property<string>("InstanceId")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsLatest")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("boolean");

                    b.Property<int>("LastStatusId")
                        .HasColumnType("integer");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PublishedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("PublishedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("StatusChangedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("StatusChangedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<string>("UniqueIdentifier")
                        .HasColumnType("text");

                    b.Property<int>("Version")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LastStatusId");

                    b.HasIndex("StatusId");

                    b.ToTable("ContractTypes", "configuration");
                });

            modelBuilder.Entity("Lithium.Configuration.Core.Elements.ContractTypeAttribute", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("AttributeId")
                        .HasColumnType("text");

                    b.Property<string>("ContractTypeId")
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("InstanceId")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int>("LastStatusId")
                        .HasColumnType("integer");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("StatusChangedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("StatusChangedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<string>("UniqueIdentifier")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.HasIndex("ContractTypeId");

                    b.HasIndex("LastStatusId");

                    b.HasIndex("StatusId");

                    b.ToTable("ContractTypeAttributes", "configuration");
                });

            modelBuilder.Entity("Lithium.Configuration.Core.Elements.DataType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DataTypes", "configuration");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Plain text",
                            IsActive = true,
                            Type = "string"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Whole numbers from -2^31 (-2,147,483,648) to 2^31-1 (2,147,483,647)",
                            IsActive = true,
                            Type = "integer"
                        },
                        new
                        {
                            Id = 3,
                            Description = "24 digit decimal number with 6 decimal places",
                            IsActive = true,
                            Type = "decimal"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Simple Yes/No",
                            IsActive = true,
                            Type = "boolean"
                        },
                        new
                        {
                            Id = 5,
                            Description = "User input through either drop down or Radio buttons or Checkboxes",
                            IsActive = true,
                            Type = "choice"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Currency inputs",
                            IsActive = true,
                            Type = "currency"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Date input",
                            IsActive = true,
                            Type = "date"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Textbox to allow user to input email",
                            IsActive = true,
                            Type = "email"
                        },
                        new
                        {
                            Id = 9,
                            Description = "0-100% with 4 decimal places",
                            IsActive = true,
                            Type = "percent"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Textbox to allow user to input url",
                            IsActive = true,
                            Type = "url"
                        },
                        new
                        {
                            Id = 11,
                            Description = "Formula input to perform simple calculations",
                            IsActive = true,
                            Type = "computed"
                        });
                });

            modelBuilder.Entity("Lithium.Configuration.Core.Elements.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer");

                    b.Property<string>("Prefix")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Features", "configuration");
                });

            modelBuilder.Entity("Lithium.Configuration.Core.Elements.Attribute", b =>
                {
                    b.HasOne("Lithium.BaseEntities.Status", "LastStatus")
                        .WithMany()
                        .HasForeignKey("LastStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lithium.BaseEntities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LastStatus");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Lithium.Configuration.Core.Elements.ContractType", b =>
                {
                    b.HasOne("Lithium.BaseEntities.Status", "LastStatus")
                        .WithMany()
                        .HasForeignKey("LastStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lithium.BaseEntities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LastStatus");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Lithium.Configuration.Core.Elements.ContractTypeAttribute", b =>
                {
                    b.HasOne("Lithium.Configuration.Core.Elements.Attribute", "Attribute")
                        .WithMany("ContractTypeAttributes")
                        .HasForeignKey("AttributeId");

                    b.HasOne("Lithium.Configuration.Core.Elements.ContractType", "ContractType")
                        .WithMany("ContractTypeAttributes")
                        .HasForeignKey("ContractTypeId");

                    b.HasOne("Lithium.BaseEntities.Status", "LastStatus")
                        .WithMany()
                        .HasForeignKey("LastStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lithium.BaseEntities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attribute");

                    b.Navigation("ContractType");

                    b.Navigation("LastStatus");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Lithium.Configuration.Core.Elements.Attribute", b =>
                {
                    b.Navigation("ContractTypeAttributes");
                });

            modelBuilder.Entity("Lithium.Configuration.Core.Elements.ContractType", b =>
                {
                    b.Navigation("ContractTypeAttributes");
                });
#pragma warning restore 612, 618
        }
    }
}
