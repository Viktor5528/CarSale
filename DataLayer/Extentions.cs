using System;
using System.Linq;
using System.Linq.Expressions;

namespace DataLayer
{
    public static class Extentions
    {
        public static IQueryable<T> WhereIfCondition<T>(this IQueryable<T> value, Expression<Func<T, bool>> filter, bool condition)
        {

            return condition
                        ? value.Where(filter)
                        : value;
        }
    }
}
