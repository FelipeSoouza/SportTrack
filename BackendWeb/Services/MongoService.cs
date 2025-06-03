using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace WebSport.Services
{
    public class MongoService<T>
    {
        private readonly IMongoCollection<T> _collection;

        public MongoService(IConfiguration config, string collectionName)
        {
            var settings = config.GetSection("MongoSettings").Get<MongoSettings>();
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<T>(collectionName);
        }

        public List<T> Get() => _collection.Find(_ => true).ToList();

        public T Get(string id) => _collection.Find(Builders<T>.Filter.Eq("Id", id)).FirstOrDefault();

        public void Create(T item) => _collection.InsertOne(item);

        public void Update(string id, T item) => _collection.ReplaceOne(Builders<T>.Filter.Eq("Id", id), item);

        public void Delete(string id) => _collection.DeleteOne(Builders<T>.Filter.Eq("Id", id));
    }
}
