using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Persistance.Utilities
{
    internal static class IQuerybleExtensions
    {
        internal static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, int pageNumber, int pageSize)
        {
            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
    }
}
