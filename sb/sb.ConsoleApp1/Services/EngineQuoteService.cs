using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using sb.ConsoleApp1.Domain;
using sb.ConsoleApp1.Services.Rules;

namespace sb.ConsoleApp1.Services
{
    public class EngineQuoteService : IEngineQuoteService
    {
        private readonly ICostCalculatorRule _costCalculator;

        public EngineQuoteService(
            ICostCalculatorRule costCalculator)
        {
            _costCalculator = costCalculator;
        }

        public Quote[] GetQuotes(CustomerRequestType req, InsurerConfigurationType config)
        {
            return (from insurer in config.InsurerRates
                let cost = this._costCalculator.GetCost(req.covers, insurer)
                where cost != 0
                select new Quote() {InsurerName = insurer.Name, Price = cost}).ToArray();
        }
        
    }
}