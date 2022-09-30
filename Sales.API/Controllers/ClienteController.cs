using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.API.Models;

namespace Sales.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ClienteController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clientes = await _context.Clientes.Where(x => x.Active).ToListAsync();

            return Ok(clientes);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var clientes = await _context.Clientes.Where(x => x.Id == id && x.Active)
                .FirstOrDefaultAsync();

            if (clientes == null)
            {
                return NotFound();
            }

            return Ok(clientes);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cliente Cliente)
        {
            _context.Clientes.Add(Cliente);
            await _context.SaveChangesAsync();

            return Ok(Cliente);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Cliente Cliente)
        {
            var cliente = await _context.Clientes.Where(x => x.Id == id && x.Active)
                .FirstOrDefaultAsync();

            if (cliente != null)
            {
                cliente.Name = Cliente.Name;
                cliente.Age = Cliente.Age;
                cliente.Active = Cliente.Active;
                cliente.Identity = Cliente.Identity;

                _context.Clientes.Update(cliente);
                await _context.SaveChangesAsync();
                
                return Ok(Cliente);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _context.Clientes.Where(x => x.Id == id && x.Active)
                .FirstOrDefaultAsync();

            if (cliente != null)
            {
                cliente.Active = false;

                _context.Clientes.Update(cliente);
                await _context.SaveChangesAsync();
                
                return NoContent();
            }

            return NotFound();
        }
    }
}