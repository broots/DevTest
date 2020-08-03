using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeveloperTest.Business;
using System;
using System.Collections.Generic;
using System.Text;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database.Models;
using System.Threading.Tasks;
using System.Linq;

namespace DeveloperTest.Business.Tests
{
    [TestClass()]
    public class MockBaseRepositoryServiceTests
    {
        readonly MockBaseRepositoryService<Customer> _customerRepository;

        public MockBaseRepositoryServiceTests()
        {
            _customerRepository = new MockBaseRepositoryService<Customer>();
            _customerRepository.Entities = LoadCustomerTestData();
        }

        [TestMethod()]
        public async Task GetAllTest()
        {
            var customers = await _customerRepository.GetAll();
            Assert.IsTrue(customers.Count > 0);
        }

        [TestMethod()]
        public async Task GetByIdTest()
        {
            var customer = await _customerRepository.GetById(1);
            var expected = "Debbi Inc";

            Assert.IsTrue(customer.Name == expected);
        }

        [TestMethod()]
        public async Task SaveTest()
        {
            var customer = new Customer { Id = 3, Name = "Socks Inc", Type = "Large" };
            await _customerRepository.Save(customer);

            Assert.IsNotNull(_customerRepository.Entities.FirstOrDefault(x => x.Id == customer.Id));
        }

        private List<Customer> LoadCustomerTestData()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "Debbi Inc", Type = "Small"},
                new Customer { Id = 2, Name = "Test Company", Type = "Large"},
            };
        }
    }
}