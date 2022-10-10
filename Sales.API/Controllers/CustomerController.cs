using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
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

        // [HttpPut]
        // [Route("{id}")]
        // public async Task<IActionResult> Put(int id, [FromBody] Customer Cliente)
        // {
        //     var cliente = await _context.Customers.Where(x => x.Id == id && x.Active)
        //         .FirstOrDefaultAsync();

        //     if (cliente != null)
        //     {
        //         cliente.Name = Cliente.Name;
        //         cliente.Age = Cliente.Age;
        //         cliente.Active = Cliente.Active;
        //         cliente.Identity = Cliente.Identity;

        //         _context.Customers.Update(cliente);
        //         await _context.SaveChangesAsync();
                
        //         return Ok(Cliente);
        //     }

        //     return NotFound();
        // }

        // [HttpDelete]
        // [Route("{id}")]
        // public async Task<IActionResult> Delete(int id)
        // {
        //     var cliente = await _context.Customers.Where(x => x.Id == id && x.Active)
        //         .FirstOrDefaultAsync();

        //     if (cliente != null)
        //     {
        //         cliente.Active = false;

        //         _context.Customers.Update(cliente);
        //         await _context.SaveChangesAsync();
                
        //         return NoContent();
        //     }

        //     return NotFound();
        // }
    }
}