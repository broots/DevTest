using DeveloperTest.Database.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperTest.Business
{
    public class CustomerService : BaseRepositoryService<Customer>
    {
        public CustomerService(IConfiguration configuration, ILogger<Customer> logger) : base(configuration, logger)
        { }
    }
}
