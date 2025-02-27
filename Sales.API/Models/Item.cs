using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Sales.API.Models
{
    public class Item
    {
        public Item(string name, decimal price)
        {
            this.Id = ObjectId.GenerateNewId().ToString();
            Name = name;
            Price = price;
            Active = true;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }
    }
}