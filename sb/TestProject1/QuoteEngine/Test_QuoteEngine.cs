using System.Collections.Generic;
using sb.ConsoleApp1.Domain;
using sb.ConsoleApp1.Services;
using sb.ConsoleApp1.Services.Rules;
using TestProject1.Common;
using Xunit;

namespace TestProject1.QuoteEngine
{
    public class Test_QuoteEngine
    {
        [Fact]
        public void Test_QuoteEngine_with_Valid_data()
        {
            var req = DataGenerator_sample1.GenerateCustomerRequest();
            var config = DataGenerator_sample1.GenerateInsurerConfig();

            var matchingEngine = new MatchingEngineRule1() as IMatchingEngineRule;
            var filterRequestItems = new FilterRequestItemsRule1() as IFilterRequestItemsRule;
            var costCalculator = new CostCalculatorRule1(matchingEngine , filterRequestItems) as ICostCalculatorRule;
            
            IEngineQuoteService sut = new EngineQuoteService( costCalculator);

            var myQuotes = sut.GetQuotes(req, config);

            Assert.Equal(8, myQuotes[0].Price);
            Assert.Equal((decimal) 7.5, myQuotes[1].Price);
        }
    }
}