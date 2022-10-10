using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Sales.API.Models
{
    public class Customer
    {
        public Customer(string name, string email, string phone, string identity)
        {
            this.Id = ObjectId.GenerateNewId().ToString();
            Name = name;
            Email = email;
            Phone = phone;
            Identity = identity;
            Active = true;
            Age = 0;
            CreatedAt = DateTime.Now;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public bool Active { get; set; }
        public string Identity { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}