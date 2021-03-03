using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Models
{
    public class SearchEventModel
    {
        public string Value { get; set; }
        public SearchType SearchType { get; set; }
    }

    public enum SearchType
    {
        Region = 1,
        SensorName = 2
    }
}
