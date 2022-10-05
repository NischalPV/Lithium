using System;
namespace Lithium.Identity.Data;

public class PersistedGrantDbContext : PersistedGrantDbContext<PersistedGrantDbContext>
{
    private readonly OperationalStoreOptions _storeOptions;
    public PersistedGrantDbContext(DbContextOptions<PersistedGrantDbContext> options, OperationalStoreOptions storeOptions) : base(options, storeOptions)
    {
        _storeOptions = storeOptions;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(GlobalConstants.DEFAULT_SCHEMA);
        base.OnModelCreating(modelBuilder);
    }
}

