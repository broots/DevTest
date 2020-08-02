using DeveloperTest.Database.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperTest.Helpers
{
    public static class Extensions
    {
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
    }
}
