using System.Collections.Generic;
using sb.ConsoleApp1.Domain;

namespace sb.ConsoleApp1.Services.Rules
{
    public interface IFilterRequestItemsRule
    {
        List<CustomerRequestType.CarItemCoverCost> FilterRequestItems(
            IEnumerable<CustomerRequestType.CarItemCoverCost> list);
    }
}