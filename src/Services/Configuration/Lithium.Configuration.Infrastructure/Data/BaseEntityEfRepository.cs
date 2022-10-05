using System;
using System.Linq.Expressions;
using Lithium.BaseEntities;
using Lithium.Configuration.Core.Interfaces;
using Lithium.DataService.Interfaces;
using Lithium.Specifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Lithium.Configuration.Infrastructure.Data
{
    public class BaseEntityEfRepository<TEntity, TKey> : IBaseEntityAsyncRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        protected readonly LithiumConfigurationDbContext _ctx;
        private readonly ILogger<BaseEntityEfRepository<TEntity, TKey>> _logger;

        public BaseEntityEfRepository(LithiumConfigurationDbContext dbContext, ILogger<BaseEntityEfRepository<TEntity, TKey>> logger)
        {
            _ctx = dbContext;
            _logger = logger;
        }

        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public Task<TEntity> AddAsync(TEntity entity, bool doSave = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TEntity entity, bool doSave = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(TKey id, bool doSave = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExists(TEntity entity, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> ListAllAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity, bool doSave = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

