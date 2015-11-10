using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace DynamicEntityFilter.Filter
{
    public static class DynamicFilter
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> source, string field, string value)
        {
            if (String.IsNullOrWhiteSpace(field) || String.IsNullOrWhiteSpace(value)) return source;

            try
            {
                PropertyInfo prop = typeof(T).GetProperty(field);
                if (prop == null) return source;

                return source.Where(PropertyEquals<T, string>(prop, value));
            }
            catch
            {
                return source;
            }
        }

        private static Expression<Func<TItem, bool>> PropertyEquals<TItem, TValue>(PropertyInfo property, TValue value)
        {
            var param = Expression.Parameter(typeof(TItem));
            var prep = Expression.Property(param, property);

            BinaryExpression body;

            switch(prep.Type.Name)
            {
                case "DateTime":
                    var dateTime = DateTime.Parse(value.ToString());
                    body = Expression.Equal(prep, Expression.Constant(dateTime));

                    break;

                case "Int32":
                    var integer32 = DateTime.Parse(value.ToString());
                    body = Expression.Equal(prep, Expression.Constant(integer32));

                    break;

                default:
                    body = Expression.Equal(prep, Expression.Constant(value));

                    break;
            }

            return Expression.Lambda<Func<TItem, bool>>(body, param);
        }
    }
}