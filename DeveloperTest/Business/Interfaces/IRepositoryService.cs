using DeveloperTest.Database.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperTest.Business.Interfaces
{
    public interface IRepositoryService<T> where T : class, IEntity
    {
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Task<T> Save(T entity);
    }
}
