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
        base.OnModelCreating(modelBuilder);
    }
}

