using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Sales.API.Models
{
    public class Order
    {
        public Order(string vendor, Customer customer)
        {
            this.Id = ObjectId.GenerateNewId().ToString();
            this.Vendor = vendor;
            this.CreatedAt = DateTime.Now;
            this.Customer = customer;
            this.Items = new List<OrderItem>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public string Vendor { get; set; }
        public DateTime CreatedAt { get; set; }
        public Customer Customer { get; set; }
        public IList<OrderItem> Items { get; set; }
        public decimal Total { get; set; }

        public void AddOrderItem(OrderItem item)
        {
            this.Items.Add(item);

            this.Total = this.Items.Sum(x => x.Price);
        }
    }
}