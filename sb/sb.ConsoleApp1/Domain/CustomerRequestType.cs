using System.Collections.Generic;

namespace sb.ConsoleApp1.Domain
{
    public class CustomerRequestType
    {

        public List<CoverItem> covers { get; set; }

        public class CoverItem
        {
            public string ItemName { get; set; }
            public int ItemCost { get; set; }
        }
    }
}