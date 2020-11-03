using System.Collections.Generic;
using sb.ConsoleApp1.Domain;

namespace sb.ConsoleApp1.Services.Rules
{
    public interface ICostCalculatorRule
    {
        decimal GetCost(List<CustomerRequestType.CarItemCoverCost> requestItemList,
            InsurerConfigurationType.Insurer insurer);
    }
}