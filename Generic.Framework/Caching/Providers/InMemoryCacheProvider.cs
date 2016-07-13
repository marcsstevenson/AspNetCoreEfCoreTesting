using System.Collections.Generic;
using System.Threading.Tasks;
using Generic.Framework.Interfaces;
using Generic.Framework.Models;

namespace Generic.Framework.Caching.Providers
{
    /// <summary>
    /// This simply stores values as static variables
    /// </summary>
    public class InMemoryCacheProvider : ICacheProvider
    {
        //public static Dictionary<string, string StringValues { get; set; }
        public static Dictionary<string, object> ObjectValues { get; set; }

        private void EnsureValuesDictionaryExists()
        {
            if (ObjectValues == null) ClearCache();
        }

        public CacheStringResponse StringGet(string cacheKey)
        {
            var cacheResponse = new CacheStringResponse();

            EnsureValuesDictionaryExists();

            if (ObjectValues.ContainsKey(cacheKey))
                cacheResponse.ReturnValue = ObjectValues[cacheKey] as string;

            return cacheResponse;
        }

        public CacheStringResponse StringSet(string cacheKey, string value)
        {
            var cacheResponse = new CacheStringResponse();

            EnsureValuesDictionaryExists();

            if (ObjectValues.ContainsKey(cacheKey))
                ObjectValues[cacheKey] = value;
            else
                ObjectValues.Add(cacheKey, value);

            cacheResponse.Stop();
            return cacheResponse;
        }

        public CacheStringResponse KeyDelete(string cacheKey)
        {
            var cacheResponse = new CacheStringResponse();

            EnsureValuesDictionaryExists();

            if (ObjectValues.ContainsKey(cacheKey))
                ObjectValues.Remove(cacheKey);

            cacheResponse.Stop();
            return cacheResponse;
        }

        /// <summary>
        /// A simple test to find if we can connect to the cache
        /// </summary>
        /// <returns></returns>
        public CacheStringResponse TestConnection()
        {
            var cacheResponse = new CacheStringResponse();

            cacheResponse.ReturnValue = null;
            return cacheResponse;
        }

        public CacheObjectResponse ObjectGet(string cacheKey)
        {
            var cacheResponse = new CacheObjectResponse();

            EnsureValuesDictionaryExists();

            if (ObjectValues.ContainsKey(cacheKey))
                cacheResponse.ReturnValue = ObjectValues[cacheKey];

            return cacheResponse;
        }

        public CacheObjectResponse ObjectSet(string cacheKey, object value)
        {
            var cacheResponse = new CacheObjectResponse();

            EnsureValuesDictionaryExists();

            if (ObjectValues.ContainsKey(cacheKey))
                ObjectValues[cacheKey] = value;
            else
                ObjectValues.Add(cacheKey, value);

            cacheResponse.Stop();
            return cacheResponse;
        }

        public string GetAddress()
        {
            return "InMemory";
        }

        public void ClearCache()
        {
            ObjectValues = new Dictionary<string, object>();
        }

        // Flag: Has Dispose already been called? 
        bool _disposed = false;

        // Public implementation of Dispose pattern callable by consumers. 
        public void Dispose()
        {
            Dispose(true);
        }

        // Protected implementation of Dispose pattern. 
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here. 
                //
            }

            // Free any unmanaged objects here. 
            //
            _disposed = true;
        }
    }
}