using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.API.Models
{
    public class OrderItem
    {
        
        public OrderItem(Item item, int quantity) 
        {
            if(quantity <= 0)
                throw new ArgumentOutOfRangeException("Quantity must have a value above 0");
            
            this.Item = item;
            this.Quantity = quantity;
            this.Price = item.Price * quantity;
        }

        public Item Item { get; set; }
        public int Quantity { get; set; }

        [Range(0, double.MaxValue, ErrorMessage ="Price value must be above 0")]
        public decimal Price { get; set; }
    }
}