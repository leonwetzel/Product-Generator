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
        protected DocumentCreator Creator;

        /// <summary>
        /// Creates a connection to the database.
        /// </summary>
        public void CreateConnection()
        {
            Client = new MongoClient();
            Database = Client.GetDatabase("wamasys");
            Collection = Database.GetCollection<BsonDocument>("products");
            Creator = new DocumentCreator();
            CreatingLoop(20000);
        }

        /// <summary>
        /// Creates the given amount of products.
        /// </summary>
        /// <param name="amount">The amount of products that should be created.</param>
        public void CreatingLoop(int amount)
        {
            for (var i = 1; i <= amount; i++)
            {
                System.Threading.Thread.Sleep(5);
                Collection.InsertOneAsync(Creator.GetDocument(i));
                Console.WriteLine("Creating: " + i);
            }
        }
    }
}
