using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace LanguageConverterGame.Extensions
{
    public static class Extensions
    {
        public static string TrimAndUpper(this string str)
        {
            return str.Trim().ToUpper();
        }

        public static EntityEntry<T> AddIfNotExists<T>(this DbSet<T> dbSet, T entity, Expression<Func<T, bool>> predicate = null) where T : class, new()
        {
            var exists = predicate != null ? dbSet.Any(predicate) : dbSet.Any();
            return exists == false ? dbSet.Add(entity) : null;
        }


    }
}
