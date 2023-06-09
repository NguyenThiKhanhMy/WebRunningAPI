using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebRunning.Lib.Models
{
    public class Searching
    {
        public int Page { get; set; }
        public int PageSize { get; set; } 
        public int TotalLimitItems { get; set; }
        public QuerySearchBy SearchBy { get; set; }
        public string OrderBy { get; set; }
    }
    public class QuerySearchBy
    {
        public string Query { get; set; }
        public object[] Values { get; set; }
    }
}
