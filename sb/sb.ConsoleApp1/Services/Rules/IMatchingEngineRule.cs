using System.Collections.Generic;
using sb.ConsoleApp1.Domain;

namespace sb.ConsoleApp1.Services.Rules
{
    public interface IMatchingEngineRule
    {
        List<CustomerRequestType.CarItemCoverCost> GetMatchedItems(
            IEnumerable<CustomerRequestType.CarItemCoverCost> relevantItems, InsurerConfigurationType.Insurer insurer);

    }
}