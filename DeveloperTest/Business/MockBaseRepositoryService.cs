using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database.Models.Interfaces;
using DeveloperTest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperTest.Business
{
    public class MockBaseRepositoryService<T> : IRepositoryService<T> where T : class, IEntity
    {
        public List<T> Entities { get; set; } = new List<T>();

        public async Task<List<T>> GetAll()
        {
            return await Task.FromResult(Entities);
        }

        public async Task<T> GetById(int id)
        {
            var entity = Entities.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(entity);
        }

        public async Task<T> Save(T entity)
        {
            entity.AddOrUpdate(Entities);
            return await Task.FromResult(entity);
        }
    }
}
