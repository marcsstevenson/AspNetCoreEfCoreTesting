using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Generic.Framework.Models
{
    [DataContract]
    public class CacheStringResponse : CacheResponse<string>
    {
        public CacheStringResponse()
            : this(true)
        {

        }

        public CacheStringResponse(bool start)
        {
            if (start) this.Start();
        }
        
        [DataMember]
        public new string ReturnValue
        {
            get { return base.ReturnValue as string; }
            set { base.ReturnValue = value; }
        }
    }
}