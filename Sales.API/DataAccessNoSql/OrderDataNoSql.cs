using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Sales.API.Models;

namespace Sales.API.DataAccessNoSql
{
    public class OrderDataNoSql
    {
        private readonly IMongoCollection<Order> collection;

        public OrderDataNoSql(IOptions<SalesDatabaseSetting> salesDatabaseSetting)
        {
            var mongoClient = new MongoClient(salesDatabaseSetting.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(salesDatabaseSetting.Value.DatabaseName);
            collection = mongoDatabase.GetCollection<Order>(salesDatabaseSetting.Value.OrderCollection);
        }

        public async Task<List<Order>> GetOrdersAsync() => await collection.Find(x => true).ToListAsync();

        public async Task<Order?> GetOrderAsync(string id) => await collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        
        public async Task CreateOrderAsync(Order order) => await collection.InsertOneAsync(order);
        public async Task UpdateOrderAsync(string id, Order order) => await collection.ReplaceOneAsync(x => x.Id == id, order);
        public async Task DeleteOrderAsync(string id) => await collection.DeleteOneAsync(x => x.Id == id);
    }

}