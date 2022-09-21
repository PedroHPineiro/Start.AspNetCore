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
            var items = await _context.Items.ToListAsync();

            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Item itemModel)
        {
            _context.Items.Add(itemModel);
            await _context.SaveChangesAsync();

            return Ok(itemModel);
        }
    }
}