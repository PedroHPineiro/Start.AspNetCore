using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Sales.API.Models;

namespace Sales.API.Services
{
    public class UserServices
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserServices(IOptions<UserDatabaseSettings> userStoreDatabaseSettings)
        {
            // Conectando ao MongoDb
            var mongoClient = new MongoClient(
         userStoreDatabaseSettings.Value.ConnectionString);

            //Concectando ao Database
            var mongoDatabase = mongoClient.GetDatabase(
                userStoreDatabaseSettings.Value.DatabaseName);

            //Criando uma Coleção dentro do Database no Mongo DB
            _userCollection = mongoDatabase.GetCollection<User>(
                userStoreDatabaseSettings.Value.UserCollectionName);
        }
        // Aqui temos o CRUD
        // Find ToListAsync nos permite ver uma lista de usuarios
        public async Task<List<User>> GetAsync() =>
        await _userCollection.Find(_ => true).ToListAsync();

        //Find Id FirstOrDefaultAsync nos permite pesquisar um usuarios pelo Id
        public async Task<User?> GetAsync(string id) =>
            await _userCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        //CreateAsync InsertOneAsync nos permite criar um Usuario 
        public async Task CreateAsync(User newUser) =>
            await _userCollection.InsertOneAsync(newUser);

        // UpdateAsync ReplaceOneAsync nos permite modificar um usuario já existente
        public async Task UpdateAsync(string id, User updatedBook) =>
            await _userCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        // RemoveAsync DeleteOneAsync nos permite excluir um usuario
        public async Task RemoveAsync(string id) =>
            await _userCollection.DeleteOneAsync(x => x.Id == id);

    }
}
