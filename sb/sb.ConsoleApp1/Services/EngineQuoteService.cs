using System.Collections.Generic;
using System.Linq;
using sb.ConsoleApp1.Domain;

namespace sb.ConsoleApp1.Services
{
    public class EngineQuoteService : IEngineQuoteService
    {
        public Quote[] GetQuotes(CustomerRequestType req, InsurerConfigurationType config)
        {
            var top3 = req.covers.OrderByDescending(x => x.ItemCost).Take(3).ToList();
            var result = new List<Quote>();

            foreach (var insurer in config.InsurerRates)
            {
                var percentage = GetPercentage(top3, insurer);

                if (percentage != 0)
                {
                    var matchedItems = top3.Where(r => insurer.CarPartsCovered.Select(x => x.ItemName).Contains(r.ItemName))
                        .ToList();
                    
                    var cost = matchedItems.Sum(x => (decimal) x.ItemCost) * percentage;

                    result.Add(
                        new Quote()
                        {
                            InsurerName = insurer.Name,
                            Price = cost
                        }
                    );
                }
            }


            return result.ToArray();
        }

        private decimal GetPercentage(List<CustomerRequestType.CarItemCoverCost> top3,
            InsurerConfigurationType.Insurer ins)
        {
            top3 = top3.OrderByDescending(x => x.ItemCost).ToList();

            var matched = top3.Where(r => ins.CarPartsCovered.Select(x=> x.ItemName).Contains(r.ItemName)).ToList();

            if (matched.Count == 2)
                return (decimal) 0.10;
            else if (matched.Count == 1)
            {
                if (matched[0].ItemName == top3[0].ItemName)
                    return (decimal) 0.20;
                else if (matched[0].ItemName == top3[1].ItemName)
                    return (decimal) 0.25;
                else
                {
                    return (decimal) 0.30;
                }
            }
            else
            {
                return (decimal) 0;
            }
        }

        private decimal GetSum(List<CustomerRequestType.CarItemCoverCost> top3, InsurerConfigurationType.Insurer ins)
        {
            top3 = top3.OrderByDescending(x => x.ItemCost).ToList();

            var matched = top3.Where(r => ins.CarPartsCovered.Select(x=> x.ItemName).Contains(r.ItemName)).ToList();

            if (matched.Count == 2)
                return (decimal) 0.10;
            else if (matched.Count == 1)
            {
                if (matched[0].ItemName == top3[0].ItemName)
                    return (decimal) 0.20;
                else if (matched[0].ItemName == top3[1].ItemName)
                    return (decimal) 0.25;
                else
                {
                    return (decimal) 0.30;
                }
            }
            else
            {
                return (decimal) 0;
            }
        }
    }
}