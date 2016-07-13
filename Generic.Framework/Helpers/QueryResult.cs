using System;
using System.Collections.Generic;
using Generic.Framework.AbstractClasses;

namespace Generic.Framework.Helpers
{
    public class QueryResult<T> : GenericResult
    {
        public Query Query { get; set; }
        public int TotalCount { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }

        public QueryResult(Query query)
            : base()
        {
            this.Query = query;
            this.Skip = query.Skip;
            this.Take = query.Take;
        }

        public QueryResult(List<T> results)
            : base()
        {
            this.Results = results;
        }
        
        public QueryResult(Exception e)
        {
            this.Error = e;
        }

        public List<T> Results { get; set; }
    }
}
