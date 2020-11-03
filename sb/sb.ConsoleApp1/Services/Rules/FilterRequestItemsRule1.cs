using System.Collections.Generic;
using System.Linq;
using sb.ConsoleApp1.Domain;

namespace sb.ConsoleApp1.Services.Rules
{
    public class FilterRequestItemsRule1 : IFilterRequestItemsRule
    {
        public List<CustomerRequestType.CarItemCoverCost> FilterRequestItems(IEnumerable<CustomerRequestType.CarItemCoverCost> list)
        {
            return list.OrderByDescending(x => x.ItemCost).Take(3).ToList();
        }
    }
}