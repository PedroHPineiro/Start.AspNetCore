using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.API.Models
{
    public class OrderItem
    {
        public OrderItem(Item item, int quantity) 
        {
            this.Item = item;
            this.Quantity = quantity;
            this.Price = item.Price * quantity;
        }

        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}