using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Generic.Framework.Models
{
    [DataContract]
    public class CacheObjectResponse : CacheResponse<object>
    {
        public CacheObjectResponse()
            : this(true)
        {

        }

        public CacheObjectResponse(bool start)
        {
            if (start) this.Start();
        }
    }
}