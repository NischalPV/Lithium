using System.Data;
using Lithium.BaseEntities;
using Lithium.Configuration.Core.AppStaging;
using Lithium.Configuration.Core.Constants;
using Lithium.Configuration.Core.Data;
using Lithium.Configuration.Core.Elements;
using Lithium.Configuration.Core.Interfaces;
using Lithium.DataService;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lithium.Configuration.Infrastructure.Data
{
    public class LithiumConfigurationDbContext: BaseDbContext
    {
        #region Properties
        internal readonly IMediator _mediator;
        #endregion

        #region ctors
        public LithiumConfigurationDbContext(DbContextOptions<LithiumConfigurationDbContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


            System.Diagnostics.Debug.WriteLine("ConfigurationDbContext::ctor ->" + this.GetHashCode());
        }

        public LithiumConfigurationDbContext(DbContextOptions<LithiumConfigurationDbContext> options) : base(options)
        {
        }
        #endregion


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema(GlobalConstants.DEFAULT_SCHEMA);
            base.OnModelCreating(builder);
            MasterData.SeedUsingMigration(builder);
        }



        #region dbsets
        // Element Db sets
        public DbSet<Core.Elements.Attribute> Attributes { get; set; }
        public DbSet<ContractCategory> ContractCategories { get; set; }
        public DbSet<ContractStage> ContractStages { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }
        public DbSet<ContractTypeAttribute> ContractTypeAttributes { get; set; }
        public DbSet<DataType> DataTypes { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Status> Statuses { get; set; }
        #endregion

    }
}

