using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Sales.API.Models;
using Sales.API.ViewModels;

namespace Sales.API.DataAccessNoSql
{
    public class ItemDataNoSql
    {
        private readonly IMongoCollection<Item> collection;

        public ItemDataNoSql(IOptions<SalesDatabaseSetting> salesDatabaseSetting)
        {
            var mongoClient = new MongoClient(salesDatabaseSetting.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(salesDatabaseSetting.Value.DatabaseName);
            collection = mongoDatabase.GetCollection<Item>(salesDatabaseSetting.Value.ItemCollection);
        }

        public async Task<List<Item>> GetItemsAsync() => await collection.Find(x => true).ToListAsync();

        public async Task<Item?> GetItemAsync(string id) => await collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        
        public async Task CreateItemAsync(Item item) => await collection.InsertOneAsync(item);
        public async Task UpdateItemAsync(string id, Item item) => await collection.ReplaceOneAsync(x => x.Id == id, item);
        public async Task DeleteItemAsync(string id) => await collection.DeleteOneAsync(id);
    }
}