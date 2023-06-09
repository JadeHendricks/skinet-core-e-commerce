using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    //TEntity === T but more specific
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec) 
        {
            var query = inputQuery;

            if (spec.Criteria != null) 
            {
                //spec.Criteria == x => x.Id == id
                query = query.Where(spec.Criteria);
            }

            if (spec.OrderBy != null) 
            {
                query = query.OrderBy(spec.OrderBy);
            }

            if (spec.OrderByDescending != null) 
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }

            if (spec.IsPagingEnable) {
                //the order of this is important because, these need to come after filter/sorting operators
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

            //taking our include statements, aggregate them and add them to our query, that we then pass to our list.
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}