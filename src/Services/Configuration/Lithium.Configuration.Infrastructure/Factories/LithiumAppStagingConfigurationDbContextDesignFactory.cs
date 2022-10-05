using System;
using Lithium.Configuration.Infrastructure.Data;
using Lithium.DataService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Lithium.Configuration.Infrastructure.Factories;

public class LithiumAppStagingConfigurationDbContextDesignFactory : IDesignTimeDbContextFactory<LithiumAppStagingConfigurationDbContext>
{
    public LithiumAppStagingConfigurationDbContext CreateDbContext(string[] args)
    {
        string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var config = new ConfigurationBuilder()
           .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
           .AddJsonFile("appsettings.json")
           .AddJsonFile($"appsettings.{environment}.json", optional: true)
           .AddEnvironmentVariables()
           .Build();

        var optionsBuilder = new DbContextOptionsBuilder<LithiumAppStagingConfigurationDbContext>();

        optionsBuilder.UseNpgsql(config["ConnectionStrings:DefaultConnection"], npgsqlOptionsAction: o => o.MigrationsAssembly("Lithium.Configuration"));

        return new LithiumAppStagingConfigurationDbContext(optionsBuilder.Options, new NoMediator());
    }
}



