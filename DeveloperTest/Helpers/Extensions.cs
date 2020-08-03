using DeveloperTest.Database.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DeveloperTest.Helpers
{
    public static class Extensions
    {
        public static T AddOrUpdate<T>(this T entity, List<T> entityCollection) where T : class, IEntity
        {
            var existing = entityCollection.FirstOrDefault(x => x.Id == entity.Id);
            if (existing != null)
                entityCollection.Remove(existing);

            entityCollection.Add(entity);

            return entity;
        }

        public static void AddOrUpdate<T>(this DbSet<T> dbSet, T record)
        where T : class, IEntity
        {
            var exists = dbSet.AsNoTracking().Any(x => x.Id.Equals(record.Id));
            if (exists)
            {
                dbSet.Update(record);
                return;
            }

            dbSet.Add(record);
        }

        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }

    }
}
