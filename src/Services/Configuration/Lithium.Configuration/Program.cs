using System.Data.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using HealthChecks.UI.Client;
using Lithium.AutofacModules;
using Lithium.BuildingBlocks.EventBus;
using Lithium.BuildingBlocks.EventBus.Abstractions;
using Lithium.BuildingBlocks.EventBusRabbitMQ;
using Lithium.BuildingBlocks.IntegrationEventLogEF.Services;
using Lithium.Configuration;
using Lithium.Configuration.Filters;
using Lithium.Configuration.Infrastructure.Data;
using Lithium.GlobalFilters;
using Lithium.IdentityService;
using Lithium.IntegrationService;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        ConfigurationManager Configuration = builder.Configuration;

        var connectionString = Configuration.GetConnectionString("DefaultConnection");

        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(autofacBuilder =>
            {
                autofacBuilder.RegisterModule(new MediatorModule());
                autofacBuilder.RegisterModule(new ApplicationModule());
            });

        builder.Services.AddCustomMvc()
            .AddHealthChecks(Configuration)
            .AddCustomDbContext(Configuration)
            .AddCustomSwagger(Configuration)
            .AddCustomIntegrations(Configuration)
            .AddCustomConfiguration(Configuration)
            .AddEventBus(Configuration)
            .AddCustomAuthentication(Configuration);

        builder.Services.AddScopedServices();

        var app = builder.Build();


        var pathBase = Configuration["PATH_BASE"];
        var oAuthClientId = Configuration["OAuthClientId"];

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        if (!string.IsNullOrEmpty(pathBase))
        {
            app.Logger.LogDebug("Using PATH BASE '{pathBase}'", pathBase);
            app.UsePathBase(pathBase);
        }

        app.UseSwagger()
               .UseSwaggerUI(c =>
               {
                   c.SwaggerEndpoint($"{(!string.IsNullOrEmpty(pathBase) ? pathBase : string.Empty)}/swagger/v1/swagger.json", "Lithium.Configuration V1");
                   c.OAuthClientId($"{oAuthClientId}");
                   c.OAuthAppName("Lithium Configuration Swagger UI");
               });

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseCors("CorsPolicy");

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            endpoints.MapDefaultControllerRoute();
            endpoints.MapControllers();

            //endpoints.MapRazorPages();

            endpoints.MapHealthChecks("/hc", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            endpoints.MapHealthChecks("/liveness", new HealthCheckOptions
            {
                Predicate = r => r.Name.Contains("self")
            });

        });

        app.Services.GetRequiredService<Lithium.BuildingBlocks.EventBus.Abstractions.IEventBus>();


        app.Run();


    }


}

static class CustomExtensionsMethods
{
    public static IServiceCollection AddCustomMvc(this IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.Filters.Add(typeof(HttpGlobalExceptionFilter));
        })
            //.AddApplicationPart(typeof(MasterdataController).Assembly)
            .AddNewtonsoftJson();

        services.AddApiVersioning(config =>
        {
            config.DefaultApiVersion = new ApiVersion(1, 0);
            config.AssumeDefaultVersionWhenUnspecified = true;
            config.ReportApiVersions = true;
            config.ApiVersionReader = new UrlSegmentApiVersionReader();
        });

        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder
                .SetIsOriginAllowed((host) => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
        });

        return services;
    }

    public static IServiceCollection AddHealthChecks(this IServiceCollection services, ConfigurationManager configuration)
    {
        var hcBuilder = services.AddHealthChecks();
        hcBuilder.AddCheck("self", () => HealthCheckResult.Healthy());

        hcBuilder
            .AddNpgSql(
                configuration["DefaultConnection"],
                name: "ConfigurationApiDb-check",
                tags: new string[] { "configurationapidb" });

        hcBuilder
            .AddRabbitMQ(
                $"amqp://{configuration["EventBusConnection"]}",
                name: "configuration-api-rabbitmqbus-check",
                tags: new string[] { "rabbitmqbus" });

        return services;
    }

    public static IServiceCollection AddCustomDbContext(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<LithiumConfigurationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), npgsqlOptionsAction: sqlOptions =>
            {
                sqlOptions.MigrationsAssembly(typeof(Program).GetTypeInfo().Assembly.GetName().Name);
                sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null);
            });
        }, ServiceLifetime.Scoped);

        services.AddDbContext<LithiumAppStagingConfigurationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), npgsqlOptionsAction: sqlOptions =>
            {
                sqlOptions.MigrationsAssembly(typeof(Program).GetTypeInfo().Assembly.GetName().Name);
                sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null);
            });
        }, ServiceLifetime.Scoped);

        services.AddDatabaseDeveloperPageExceptionFilter();

        return services;
    }

    public static IServiceCollection AddCustomSwagger(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddSwaggerGen(options =>
        {
            //options.DescribeAllEnumsAsStrings();

            options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "Lithium Configuration - HTTP API",
                Version = "v1",
                Description = "The Lithium Configuration Service HTTP API"
            });

            options.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.OAuth2,
                Flows = new Microsoft.OpenApi.Models.OpenApiOAuthFlows()
                {
                    Implicit = new Microsoft.OpenApi.Models.OpenApiOAuthFlow()
                    {
                        AuthorizationUrl = new Uri($"{configuration.GetValue<string>("ExternalIdentityUrl")}/connect/authorize"),
                        TokenUrl = new Uri($"{configuration.GetValue<string>("ExternalIdentityUrl")}/connect/token"),
                        Scopes = new Dictionary<string, string>()
                            {
                                {"ConfigurationAPI", "Configuration API Scope" }
                            }
                    }
                }
            });

            options.OperationFilter<AuthorizeCheckOperationFilter>();
        });

        return services;
    }

    public static IServiceCollection AddCustomIntegrations(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddTransient<Func<DbConnection, IIntegrationEventLogService>>(
            sp => (DbConnection c) => new IntegrationEventLogService(c));

        services.AddTransient<IApiIntegrationEventService, ApiIntegrationEventService<LithiumConfigurationDbContext>>();

        services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
        {
            var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();


            var factory = new ConnectionFactory()
            {
                HostName = configuration["EventBus:ConnectionString"],
                DispatchConsumersAsync = true
            };

            if (!string.IsNullOrEmpty(configuration["EventBus:Username"]))
            {
                factory.UserName = configuration["EventBus:Username"];
            }

            if (!string.IsNullOrEmpty(configuration["EventBus:Password"]))
            {
                factory.Password = configuration["EventBus:Password"];
            }

            var retryCount = 5;
            if (!string.IsNullOrEmpty(configuration["EventBus:RetryCount"]))
            {
                retryCount = int.Parse(configuration["EventBus:RetryCount"]);
            }

            return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
        });

        return services;
    }

    public static IServiceCollection AddCustomConfiguration(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddOptions();
        services.Configure<AppSettings>(configuration);

        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Instance = context.HttpContext.Request.Path,
                    Status = StatusCodes.Status400BadRequest,
                    Detail = "Please refer to the errors property for additional details."
                };

                return new BadRequestObjectResult(problemDetails)
                {
                    ContentTypes = { "application/problem+json", "application/problem+xml" }
                };
            };
        });

        return services;
    }

    public static IServiceCollection AddEventBus(this IServiceCollection services, ConfigurationManager configuration)
    {
        var subscriptionClientName = configuration["EventBus:SubscriptionClientName"];

        services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
        {
            var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
            var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
            var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
            var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

            var retryCount = 5;
            if (!string.IsNullOrEmpty(configuration["EventBus:RetryCount"]))
            {
                retryCount = int.Parse(configuration["EventBus:RetryCount"]);
            }

            return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, iLifetimeScope, eventBusSubcriptionsManager, subscriptionClientName, retryCount);
        });

        services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();

        return services;
    }

    public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, ConfigurationManager configuration)
    {
        // prevent from mapping "sub" claim to nameidentifier.
        JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

        //var identityUrl = "https://uecpl-identity";
        var identityUrl = configuration.GetValue<string>("IdentityUrl");
        var jwtAudience = configuration.GetValue<string>("JWT:Audience");
        //Console.WriteLine($"IdentityUrl : {identityUrl}");

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(options =>
        {
            options.Authority = identityUrl;
            options.RequireHttpsMetadata = false;
            options.Audience = jwtAudience;
            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false
            };
            //options.Audience = "devices";
        });

        return services;
    }
}
