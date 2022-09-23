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
    public class ItemController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ItemController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _context.Items.Where(x => x.Active).ToListAsync();

            return Ok(items);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _context.Items.Where(x => x.Id == id && x.Active)
                .FirstOrDefaultAsync();

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Item itemModel)
        {
            _context.Items.Add(itemModel);
            await _context.SaveChangesAsync();

            return Ok(itemModel);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Item itemModel)
        {
            var item = await _context.Items.Where(x => x.Id == id && x.Active)
                .FirstOrDefaultAsync();

            if (item != null)
            {
                item.Name = itemModel.Name;
                item.Price = itemModel.Price;
                item.Active = itemModel.Active;

                _context.Items.Update(item);
                await _context.SaveChangesAsync();
                
                return Ok(itemModel);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Items.Where(x => x.Id == id && x.Active)
                .FirstOrDefaultAsync();

            if (item != null)
            {
                item.Active = false;

                _context.Items.Update(item);
                await _context.SaveChangesAsync();
                
                return NoContent();
            }

            return NotFound();
        }
    }
}