using System.Threading.Tasks;
using Generic.Framework.Interfaces;
using Generic.Framework.Models;

namespace Generic.Framework.Caching.Providers
{
    /// <summary 
    /// This provides no caching so that the user of this provider will always get the data from the database persistence
    /// </summary 
    public class NoCacheProvider : ICacheProvider
    {
        public CacheStringResponse StringGet(string cacheKey)
        {
            return new CacheStringResponse(false);
        }

        public CacheStringResponse StringSet(string cacheKey, string value)
        {
            //We don't care
            return new CacheStringResponse(false);
        }

        public CacheStringResponse KeyDelete(string cacheKey)
        {
            return new CacheStringResponse(false);
        }

        public CacheStringResponse TestConnection()
        {
            var cacheResponse = new CacheStringResponse();

            cacheResponse.ReturnValue = null;
            return cacheResponse;
        }

        public CacheObjectResponse ObjectGet(string cacheKey)
        {
            return new CacheObjectResponse(false);
        }

        public CacheObjectResponse ObjectSet(string cacheKey, object value)
        {
            return new CacheObjectResponse(false);
        }

        public string GetAddress()
        {
            throw new System.NotImplementedException();
        }

        public void ClearCache()
        {
            //Twiddle thumbs
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