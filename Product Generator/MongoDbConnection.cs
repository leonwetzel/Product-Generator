using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Product_Generator
{
    public class MongoDbConnection
    {
        protected static IMongoClient Client;
        protected static IMongoDatabase Database;
        protected static IMongoCollection<BsonDocument> Collection;
        protected DocumentBuilder Builder;
        private const int AmountOfProducts = 100000;

        /// <summary>
        /// Creates a connection to the database.
        /// </summary>
        public void CreateConnection()
        {
            Client = new MongoClient();
            Database = Client.GetDatabase("wamasys");
            Collection = Database.GetCollection<BsonDocument>("products");
            Builder = new DocumentBuilder();
            CreateProducts(AmountOfProducts);
        }

        /// <summary>
        /// Creates a given amount of products.
        /// </summary>
        /// <param name="amount">The amount of products that should be created.</param>
        public void CreateProducts(int amount)
        {
            for (var i = 1; i <= amount; i++)
            {
                System.Threading.Thread.Sleep(5);
                Collection.InsertOneAsync(Builder.GetDocument(i+amount));
                Console.WriteLine("Creating: " + (i+ AmountOfProducts));
            }
        }
    }
}
