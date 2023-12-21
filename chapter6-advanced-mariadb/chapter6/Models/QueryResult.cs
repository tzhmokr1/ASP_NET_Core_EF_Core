using System;
using System.Linq;

namespace chapter6.Models
{
    public class QueryResult
    {
        public int ProductId { get; set; }
        public string StationName { get; set; }

        public override string ToString()
        {
            return $"Id: {ProductId} - Name: {StationName}";
        }
    }
}