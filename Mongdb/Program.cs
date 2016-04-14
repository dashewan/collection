using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
namespace Mongdb
{
    class Program
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        static void Main(string[] args)
        {
            //链接mongodb
            _client = new MongoClient();
            _database = _client.GetDatabase("test");
            //插入
            //InsertOneAsync();
            //查询
            FindAsync();
            Console.ReadLine();

        }
        static async void InsertOneAsync()
        {
            var collection = _database.GetCollection<BsonDocument>("restaurants");
            //插入数据
            var document = new BsonDocument
            {
                {"address",new BsonDocument
                {
                    { "street", "2 Avenue" },
                    { "zipcode", "10075" },
                    { "building", "1480" },
                    {"coord",new BsonArray{73.9557413, 40.7720266 }}

                }
                },
                { "borough", "Manhattan" },
                { "cuisine", "Italian" },
                { "grades", new BsonArray
                    {
                        new BsonDocument
                        {
                            { "date", new DateTime(2014, 10, 1, 0, 0, 0, DateTimeKind.Utc) },
                            { "grade", "A" },
                            { "score", 11 }
                        },
                        new BsonDocument
                        {
                            { "date", new DateTime(2014, 1, 6, 0, 0, 0, DateTimeKind.Utc) },
                            { "grade", "B" },
                            { "score", 17 }
                        }
                    }
                },
                { "name", "Vella" },
                { "restaurant_id", "41704620" }

            };
            await collection.InsertOneAsync(document);
        }
        static async void FindAsync()
        {
            var collection = _database.GetCollection<BsonDocument>("restaurants");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("address.zipcode", "10075") | builder.Eq("cuisine", "Italian");
            var result = await collection.Find(filter).ToListAsync();
            Console.Write(result.Count);
        }
    }
}
