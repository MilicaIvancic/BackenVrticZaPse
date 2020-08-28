using Aplication.Paginate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplication.Extensions
{


    public static class IQueryableExtensions
    {
        public static PaginateResponse<T> PaginateOne<T> (this IQueryable<T> query, int page, int perPage)
        {
             var resultQuery = query
                .Skip((page - 1) * perPage)
                .Take(perPage);

            return new PaginateResponse<T>
            {
                Count = query.Count(),
                CurrentPage = page,
                PerPage = perPage,
                Results = resultQuery.ToList()
            };

            //return new PaginatedData<T>(resultQuery, query.Count());

            //problem sa T od queryja pa smo pravili klasu bo je problem sa countom argument missing engseption..
        }

        public static PaginateResponse<TDto> Paginate<TEntity, TDto>(this IQueryable<TEntity> query, int perPage, int page, Func<TEntity, TDto> transform)
        {
            var resultQuery = query
                .Skip((page - 1) * perPage)
                .Take(perPage);

            return new PaginateResponse<TDto>
            {
                Count = query.Count(),
                CurrentPage = page,
                PerPage = perPage,
                Results = resultQuery.Select(transform)
            };
        }
    }
}