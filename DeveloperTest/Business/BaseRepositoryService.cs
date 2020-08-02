using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models.Interfaces;
using DeveloperTest.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperTest.Business
{
    public class BaseRepositoryService<T> : IRepositoryService<T> where T : class, IEntity
    {
        private readonly ILogger<T> _logger;
        private readonly DbContextOptions<ApplicationDbContext> _dbOptions;
        private readonly IConfiguration _configuration;

        public BaseRepositoryService(IConfiguration configuration, ILogger<T> logger) : this("DefaultConnection", configuration, logger)
        { }

        public BaseRepositoryService(string dbConnectionString, IConfiguration configuration, ILogger<T> logger)
        {
            _configuration = configuration;
            _logger = logger;
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _dbOptions = optionsBuilder.UseSqlServer(_configuration.GetConnectionString(dbConnectionString)).Options;
        }
        public async Task<List<T>> GetAll()
        {
            using (var dbContext = new ApplicationDbContext(_dbOptions))
            {
                var result = await dbContext.Set<T>().ToListAsync();

                return result;
            }
        }

        public async Task<T> GetById(int id)
        {
            using (var dbContext = new ApplicationDbContext(_dbOptions))
            {
                var result = await dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

                return result;
            }
        }

        public async Task<T> Save(T entity)
        {
            using (var dbContext = new ApplicationDbContext(_dbOptions))
            {
                dbContext.Set<T>().AddOrUpdate<T>(entity);

                await dbContext.SaveChangesAsync();
            }

            return entity;
        }
    }
}
