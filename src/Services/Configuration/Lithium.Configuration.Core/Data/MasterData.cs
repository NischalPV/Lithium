using System;
using System.Security.AccessControl;
using Lithium.BaseEntities;
using Lithium.Configuration.Core.Elements;
using Microsoft.EntityFrameworkCore;

namespace Lithium.Configuration.Core.Data;

public class MasterData
{

    public static void SeedUsingMigration(ModelBuilder modelBuilder)
    {
        DefaultStatus(modelBuilder);
        DefaultCLMStages(modelBuilder);
        DefaultDataTypes(modelBuilder);
        DefaultContractCategories(modelBuilder);
    }

    private static void DefaultStatus(ModelBuilder modelBuilder)
    {
        List<Status> statuses = new();

        statuses.Add(new Status() { Id = 1, Name = "Draft" });
        statuses.Add(new Status() { Id = 2, Name = "Waiting for Approval" });
        statuses.Add(new Status() { Id = 3, Name = "Approved" });
        statuses.Add(new Status() { Id = 4, Name = "Published" });
        statuses.Add(new Status() { Id = 5, Name = "Executed" });
        statuses.Add(new Status() { Id = 6, Name = "Expired" });
        statuses.Add(new Status() { Id = 7, Name = "Renewed" });
        statuses.Add(new Status() { Id = 8, Name = "Terminated" });

        statuses.ForEach(s => modelBuilder.Entity<Status>().HasData(s));

    }

    private static void DefaultContractCategories(ModelBuilder modelBuilder)
    {
        List<ContractCategory> contractCategories = new();

        contractCategories.Add(new ContractCategory() { Id = 1, Name = "Agreement" });
        contractCategories.Add(new ContractCategory() { Id = 2, Name = "Annexure" });
        contractCategories.Add(new ContractCategory() { Id = 3, Name = "Masterdata" });
        contractCategories.Add(new ContractCategory() { Id = 4, Name = "Contract Request" });

        contractCategories.ForEach(c => modelBuilder.Entity<ContractCategory>().HasData(c));
    }

    private static void DefaultCLMStages(ModelBuilder modelBuilder)
    {
        List<ContractStage> contractStages = new();

        contractStages.Add(new ContractStage() { Id = 1, Stage = "Template Authoring" });
        contractStages.Add(new ContractStage() { Id = 2, Stage = "Contract Creation" });
        contractStages.Add(new ContractStage() { Id = 3, Stage = "Contract Review" });
        contractStages.Add(new ContractStage() { Id = 4, Stage = "Contract Approval" });
        contractStages.Add(new ContractStage() { Id = 5, Stage = "Contract Execution" });
        contractStages.Add(new ContractStage() { Id = 6, Stage = "Contract Performance" });
        contractStages.Add(new ContractStage() { Id = 7, Stage = "Contract Expiry" });

        contractStages.ForEach(c => modelBuilder.Entity<ContractStage>().HasData(c));
    }

    private static void DefaultDataTypes(ModelBuilder modelBuilder)
    {
        List<DataType> dataTypes = new();

        dataTypes.Add(new DataType() { Id = 1,  Type = "string",    Description = "Plain text" });
        dataTypes.Add(new DataType() { Id = 2,  Type = "integer",   Description = "Whole numbers from -2^31 (-2,147,483,648) to 2^31-1 (2,147,483,647)" });
        dataTypes.Add(new DataType() { Id = 3,  Type = "decimal",   Description = "24 digit decimal number with 6 decimal places" });
        dataTypes.Add(new DataType() { Id = 4,  Type = "boolean",   Description = "Simple Yes/No" });
        dataTypes.Add(new DataType() { Id = 5,  Type = "choice",    Description = "User input through either drop down or Radio buttons or Checkboxes" });
        dataTypes.Add(new DataType() { Id = 6,  Type = "currency",  Description = "Currency inputs" });
        dataTypes.Add(new DataType() { Id = 7,  Type = "date",      Description = "Date input" });
        dataTypes.Add(new DataType() { Id = 8,  Type = "email",     Description = "Textbox to allow user to input email" });
        dataTypes.Add(new DataType() { Id = 9,  Type = "percent",   Description = "0-100% with 4 decimal places" });
        dataTypes.Add(new DataType() { Id = 10, Type = "url",       Description = "Textbox to allow user to input url" });
        dataTypes.Add(new DataType() { Id = 11, Type = "computed",  Description = "Formula input to perform simple calculations" });

        dataTypes.ForEach(d => modelBuilder.Entity<DataType>().HasData(d));

    }
}

