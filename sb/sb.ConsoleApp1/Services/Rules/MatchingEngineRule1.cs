using System.Collections.Generic;
using System.Linq;
using sb.ConsoleApp1.Domain;

namespace sb.ConsoleApp1.Services.Rules
{
    

    public class MatchingEngineRule1 :IMatchingEngineRule
    {
        public List<CustomerRequestType.CarItemCoverCost> GetMatchedItems(
            IEnumerable<CustomerRequestType.CarItemCoverCost> relevantItems, InsurerConfigurationType.Insurer insurer)
        {
            return relevantItems.Where(r => insurer.CarPartsCovered.Select(x => x.ItemName).Contains(r.ItemName)).ToList();
        }
    }
}