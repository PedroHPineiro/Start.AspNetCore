using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Sales.API.Models;

namespace Sales.API.DataAccessNoSql
{
    public class CustomerDataNoSql
    {
        private readonly IMongoCollection<Customer> collection;

        public CustomerDataNoSql(IOptions<SalesDatabaseSetting> salesDatabaseSetting)
        {
            var mongoClient = new MongoClient(salesDatabaseSetting.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(salesDatabaseSetting.Value.DatabaseName);
            collection = mongoDatabase.GetCollection<Customer>(salesDatabaseSetting.Value.CustomerCollection);
        }

        public async Task<List<Customer>> GetCustomersAsync() => await collection.Find(x => true).ToListAsync();

        public async Task<Customer?> GetCustomerAsync(string id) => await collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        
        public async Task CreateCustomerAsync(Customer customer) => await collection.InsertOneAsync(customer);
        public async Task UpdateCustomerAsync(string id, Customer customer)=> await collection.ReplaceOneAsync(x => x.Id == id, customer);
        public async Task DeleteCustomerAsync(string id) => await collection.DeleteOneAsync(id);
    }
}