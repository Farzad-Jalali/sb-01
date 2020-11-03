using System.Collections.Generic;
using System.Linq;
using sb.ConsoleApp1.Domain;

namespace sb.ConsoleApp1.Services.Rules
{
    public class CostCalculatorRule1 : ICostCalculatorRule
    {
        private readonly IMatchingEngineRule _matchingEngine;
        private readonly IFilterRequestItemsRule _filterRequestItems;

        public CostCalculatorRule1(IMatchingEngineRule matchingEngine, IFilterRequestItemsRule filterRequestItems)
        {
            _matchingEngine = matchingEngine;
            _filterRequestItems = filterRequestItems;
        }

        public decimal GetCost(List<CustomerRequestType.CarItemCoverCost> requestItemList,
            InsurerConfigurationType.Insurer insurer)
        {
            return GetSum(requestItemList, insurer) * GetPercentage(requestItemList, insurer);
        }

        private decimal GetPercentage(IEnumerable<CustomerRequestType.CarItemCoverCost> requestItemList,
            InsurerConfigurationType.Insurer insurer)
        {
            var relevantItems = this._filterRequestItems.FilterRequestItems(requestItemList);

            var matched = this._matchingEngine.GetMatchedItems(relevantItems, insurer);

            return matched.Count switch
            {
                2 => (decimal) 0.10,
                1 when matched[0].ItemName == relevantItems[0].ItemName => (decimal) 0.20,
                1 when matched[0].ItemName == relevantItems[1].ItemName => (decimal) 0.25,
                1 => (decimal) 0.30,
                _ => (decimal) 0
            };
        }

        private decimal GetSum(IEnumerable<CustomerRequestType.CarItemCoverCost> carItemCoverCostsList,
            InsurerConfigurationType.Insurer insurer)
        {
            var relevantItems = this._filterRequestItems.FilterRequestItems(carItemCoverCostsList);
            var matched = this._matchingEngine.GetMatchedItems(relevantItems, insurer);

            return matched.Sum(x => x.ItemCost);
        }
    }
}