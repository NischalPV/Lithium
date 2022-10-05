using System;
using Lithium.BaseEntities;
using Lithium.Configuration.Core.AppStaging;
using Lithium.Configuration.Core.Constants;
using Lithium.Configuration.Core.Data;
using Lithium.Configuration.Core.Elements;
using Lithium.DataService;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lithium.Configuration.Infrastructure.Data
{
    public class LithiumAppStagingConfigurationDbContext: BaseAppStagingDbContext
    {
        #region Properties
        internal readonly IMediator _mediator;
        #endregion

        #region ctors
        public LithiumAppStagingConfigurationDbContext(DbContextOptions<LithiumAppStagingConfigurationDbContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


            System.Diagnostics.Debug.WriteLine("ConfigurationDbContext::ctor ->" + this.GetHashCode());
        }

        public LithiumAppStagingConfigurationDbContext(DbContextOptions<LithiumAppStagingConfigurationDbContext> options) : base(options)
        {
        }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema(GlobalConstants.APPSTAGING_SCHEMA);
            base.OnModelCreating(builder);
            //MasterData.SeedUsingMigration(builder);
        }

        #region dbsets
        // App Staging Db sets
        public DbSet<AppStagingAttribute> AppStagingAttributes { get; set; }
        public DbSet<AppStagingContractType> AppStagingContractTypes { get; set; }

        #endregion
    }
}

