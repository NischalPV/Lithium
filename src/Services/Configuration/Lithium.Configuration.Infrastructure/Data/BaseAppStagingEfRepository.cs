using System;
using System.Linq.Expressions;
using Lithium.BaseEntities;
using Lithium.Configuration.Core.Interfaces;
using Lithium.Configuration.Core.Interfaces.AppStaging;
using Lithium.DataService.Interfaces;
using Lithium.Specifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Lithium.Configuration.Infrastructure.Data
{
    public class BaseAppStagingEfRepository<TEntity, TKey> : IBaseAppStagingAsyncRepository<TEntity, TKey> where TEntity : BaseAppStaging<TKey>
    {
        #region properties
        protected readonly LithiumAppStagingConfigurationDbContext _ctx;
        private readonly ILogger<BaseAppStagingEfRepository<TEntity, TKey>> _logger;
        #endregion

        #region ctor
        public BaseAppStagingEfRepository(LithiumAppStagingConfigurationDbContext ctx, ILogger<BaseAppStagingEfRepository<TEntity, TKey>> logger)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        #endregion

        #region interface implementation
        public IUnitOfWork UnitOfWork { get { return _ctx; } }

        public async Task<TEntity> AddAsync(TEntity entity, bool doSave = true, CancellationToken cancellationToken = default)
        {
            if (doSave)
            {
                try
                {
                    var result = await _ctx.Set<TEntity>().AddAsync(entity);
                    entity = result.Entity;
                    await _ctx.SaveChangesAsync();
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, $"An error occured while adding entity: {typeof(TEntity).Name}");
                }
            }
            else
            {
                if (entity.IsTransient())
                {
                    return _ctx.Set<TEntity>().Add(entity).Entity;
                }
                else
                {
                    return entity;
                }
            }

            return entity;

        }

        public async Task<int> CountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return await ApplySpecification(specification).CountAsync();
        }

        public async Task DeleteAsync(TEntity entity, bool doSave = true, CancellationToken cancellationToken = default)
        {
            entity.IsActive = false;
            await UpdateAsync(entity, doSave);
        }

        public async Task DeleteByIdAsync(TKey id, bool doSave = true, CancellationToken cancellationToken = default)
        {
            var entity = await GetByIdAsync(id);
            await DeleteAsync(entity, doSave);
        }

        public async Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
        {
            return await _ctx.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetByIdAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<bool> IsExists(TEntity entity, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _ctx.Set<TEntity>().AnyAsync(predicate);
        }

        public async Task<List<TEntity>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await _ctx.Set<TEntity>().Where(e => e.IsActive).ToListAsync();
        }

        public async Task<List<TEntity>> ListAllAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, bool doSave = true, CancellationToken cancellationToken = default)
        {
            if (doSave)
            {
                try
                {
                    var result = _ctx.Entry<TEntity>(entity);
                    result.State = EntityState.Modified;
                    entity = result.Entity;
                    await _ctx.SaveChangesAsync();
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, $"An error occured while updating entity: {typeof(TEntity).Name}");
                }
            }
            else
            {
                return _ctx.Set<TEntity>().Update(entity).Entity;
            }

            return entity;
        }

        #endregion

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> spec)
        {
            return AppStagingSpecificationEvaluator<TEntity, TKey>.GetQuery(_ctx.Set<TEntity>().AsQueryable(), spec);
        }
    }
}

