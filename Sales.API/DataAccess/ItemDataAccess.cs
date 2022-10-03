using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sales.API.Models;

namespace Sales.API.DataAccess
{
    public class ItemDataAccess : IItemDataAccess //SQL (in memory)
    {
        private readonly DatabaseContext _context;

        public ItemDataAccess(DatabaseContext context)
        {
            _context = context;
        }

        public async Task DeleteOne(int id)
        {
            var item = await _context.Items.Where(x => x.Id == id && x.Active)
                .FirstOrDefaultAsync();

            if (item != null)
            {
                item.Active = false;

                _context.Items.Update(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Item> GetItem(int id)
        {
            var item = await _context.Items.Where(x => x.Id == id && x.Active)
                .FirstOrDefaultAsync();

            return item;
        }

        public async Task<IList<Item>> GetItems()
        {
            var items = await _context.Items.Where(x => x.Active).ToListAsync();

            return items;
        }

        public async Task<Item> InsertOne(Item model)
        {
            _context.Items.Add(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<Item> UpdateOne(int id, Item model)
        {
            var item = await _context.Items.Where(x => x.Id == id && x.Active)
                .FirstOrDefaultAsync();

            if (item != null)
            {
                item.Name = model.Name;
                item.Price = model.Price;
                item.Active = model.Active;

                _context.Items.Update(item);
                await _context.SaveChangesAsync();
                
                return model;
            }

            return null;
        }
    }
}