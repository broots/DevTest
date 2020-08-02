using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperTest.Controllers
{
    [ApiController, Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IRepositoryService<Customer> _customerService;
        private readonly IMapper _mapper;

        public CustomerController(IRepositoryService<Customer> customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _customerService.GetAll();
            var result = _mapper.Map<IEnumerable<CustomerModel>>(data);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _customerService.GetById(id);

            if (data == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<CustomerModel>(data);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = _mapper.Map<Customer>(model);
                customer = await _customerService.Save(customer);
                return Created($"customer/{customer.Id}", customer); 
            }

            return BadRequest(ModelState);
        }
    }
}
