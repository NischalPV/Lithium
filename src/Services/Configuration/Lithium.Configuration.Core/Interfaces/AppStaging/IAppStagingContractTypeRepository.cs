using System;
using System.Linq.Expressions;
using Lithium.BaseEntities;
using Lithium.DataService.Interfaces;
using Lithium.Specifications;

namespace Lithium.Configuration.Core.Interfaces.AppStaging;

public interface IBaseAppStagingAsyncRepository<TEntity, TKey> where TEntity : BaseAppStaging<TKey>
{
    IUnitOfWork UnitOfWork { get; }

    /// <summary>
    /// Fetch entity of type TEntity from database based on Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Single Entity having id</returns>
    Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetches entity of type TEntity based on specification
    /// </summary>
    /// <param name="specification"></param>
    /// <returns>Single Entity filtered by specification</returns>
    Task<TEntity> GetByIdAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);

    /// <summary>
    /// Lists all active entities of type TEntity
    /// </summary>
    /// <returns>List of active entities in database</returns>
    Task<List<TEntity>> ListAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Lists all active entities of type TEntity filtered by specification
    /// </summary>
    /// <param name="specification"></param>
    /// <returns>List of active entities filetered by specification</returns>
    Task<List<TEntity>> ListAllAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates new entity and saves it to database
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="doSave"></param>
    /// <returns>Created entity</returns>
    Task<TEntity> AddAsync(TEntity entity, bool doSave = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates a given entity of type TEntity
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="doSave"></param>
    /// <returns>Updated entity</returns>
    Task<TEntity> UpdateAsync(TEntity entity, bool doSave = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deactivates given entity of type TEntity
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="doSave"></param>
    /// <returns></returns>
    Task DeleteAsync(TEntity entity, bool doSave = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deactivates entity having id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="doSave"></param>
    /// <returns></returns>
    Task DeleteByIdAsync(TKey id, bool doSave = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Counts number of entities in database based on specification
    /// </summary>
    /// <param name="specification"></param>
    /// <returns>Count of entities</returns>
    Task<int> CountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);

    /// <summary>
    /// Checks if entity of type TEntity is present in database
    /// </summary>
    /// <param name="entity">entity to be checked</param>
    /// <param name="predicate">Predicate to be checked with</param>
    /// <returns>True if entity exists, otherwise False</returns>
    Task<bool> IsExists(TEntity entity, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

    /// <summary>
    /// Checks if entity of type TEntity is present in database
    /// </summary>
    /// <param name="id">Id of the entity</param>
    /// <returns>True if entity exists, otherwise False</returns>
    //Task<bool> IsExists(TKey id, CancellationToken cancellationToken = default);


}

