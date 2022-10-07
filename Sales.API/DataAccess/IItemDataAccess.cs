using Sales.API.Models;

namespace Sales.API.DataAccess
{
    public interface IItemDataAccess
    {
        Task<Item> InsertOne(Item model);
        Task<Item> GetItem(int id);
        Task<IList<Item>> GetItems();
        Task<Item> UpdateOne(int id, Item model);
        Task DeleteOne(int id);
    }
}