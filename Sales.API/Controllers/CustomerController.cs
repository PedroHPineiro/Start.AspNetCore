using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using Sales.API.DataAccess;
using Sales.API.DataAccessNoSql;
using Sales.API.Models;
using Sales.API.ViewModels;

namespace Sales.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerDataNoSql _context;

        public CustomerController(CustomerDataNoSql context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _context.GetCustomersAsync();

            return Ok(customers);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var customer = await _context.GetCustomerAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = new Customer(inputModel.Name, inputModel.Email, inputModel.Phone, inputModel.Identity);            
            
            await _context.CreateCustomerAsync(model);

            return Ok(inputModel);
        }

         [HttpPut]
         [Route("{id}")]
         public async Task<IActionResult> Put(string id, [FromBody] CustomerInputModel CustomerModel)
         {
            var customer = await _context.GetCustomerAsync(id);

            if (customer == null)
                return NotFound("Customer doesn't exist");

            customer.Name = CustomerModel.Name;
            customer.Email = CustomerModel.Email;
            customer.Phone = CustomerModel.Phone;
            customer.Age = CustomerModel.Age;
            customer.Identity = CustomerModel.Identity;

            await _context.UpdateCustomerAsync(id, customer);

            return Ok(customer);

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var client = await _context.GetCustomerAsync(id);
            if (client == null)
                return NotFound("Id doesn't exist");

            await _context.DeleteCustomerAsync(id);

            return NoContent();
        }
    }
}