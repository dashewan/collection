using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisOperate
{
    class BasicUsage
    {
        private IDatabase GetConnection()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            IDatabase db = redis.GetDatabase();
            return db;

        }
        public bool SetString(string key, string value)
        {
            IDatabase db = GetConnection();
            return db.StringSet(key, value);
        }
        public string GetString(string key)
        {
            IDatabase db = GetConnection();
            return db.StringGet(key);
        }
        

        //public bool SetString(byte[] key, byte[] value)
        //{
        //    IDatabase db = GetConnection();
        //    return db.StringSet(key, value);
        //}
        //public string GetString(byte[] key)
        //{
        //    IDatabase db = GetConnection();
        //    return db.StringGet(key);
        //}


    }
}
