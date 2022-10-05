using System;
using Lithium.BaseEntities;
using Microsoft.EntityFrameworkCore;

namespace Lithium.Specifications;

public class AppStagingSpecificationEvaluator<TEntity, TKey> where TEntity : BaseAppStaging<TKey>
{
    public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification)
    {
        var query = inputQuery;

        if (specification.Criteria != null)
        {
            query = query.Where(specification.Criteria);
        }

        if (specification.Includes != null && specification.Includes.Count > 0)
        {
            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
        }

        if (specification.IncludeStrings != null && specification.IncludeStrings.Count > 0)
        {
            query = specification.IncludeStrings.Aggregate(query, (current, include) => current.Include(include));
        }

        if (specification.OrderBy != null)
        {
            query = query.OrderBy(specification.OrderBy);
        }

        if (specification.OrderByDescending != null)
        {
            query = query.OrderByDescending(specification.OrderByDescending);
        }

        if (specification.Page > 0 && specification.PageSize > 0)
        {
            query = query.Skip((specification.Page - 1) * specification.PageSize).Take(specification.PageSize);
        }

        return query;
    }
}

