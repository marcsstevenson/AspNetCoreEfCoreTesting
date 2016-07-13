using System;
using System.Threading.Tasks;
using Generic.Framework.Models;

namespace Generic.Framework.Interfaces
{
    public interface ICacheProvider
    {
         CacheStringResponse  StringGet(string cacheKey);

         CacheStringResponse  StringSet(string cacheKey, string value);

         CacheStringResponse  KeyDelete(string cacheKey);

         CacheStringResponse  TestConnection();

         CacheObjectResponse  ObjectGet(string cacheKey);

         CacheObjectResponse  ObjectSet(string cacheKey, object value);

        void ClearCache();

        string GetAddress();
    }
}