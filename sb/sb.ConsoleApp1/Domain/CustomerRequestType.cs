using System.Collections.Generic;

namespace sb.ConsoleApp1.Domain
{
    public class CustomerRequestType
    {
        public List<CarItemCoverCost> covers { get; set; }
        
        public sealed class CarItemCoverCost  : ICarItemType
        {
            public string ItemName { get; set; }
            public int ItemCost { get; set; }
        }
    }
}