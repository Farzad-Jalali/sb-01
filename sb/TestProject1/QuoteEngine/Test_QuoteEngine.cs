using System.Collections.Generic;
using sb.ConsoleApp1.Domain;
using sb.ConsoleApp1.Services;
using Xunit;

namespace TestProject1.QuoteEngine
{
    public class Test_QuoteEngine
    {
        [Fact]
        public void Test_QuoteEngine_with_Valid_data()
        {

            var req = new CustomerRequestType()
            {
                covers = new List<CustomerRequestType.CoverItem>()
                {
                    new CustomerRequestType.CoverItem() { ItemName = "tires", ItemCost =10 },
                    new CustomerRequestType.CoverItem() { ItemName = "windows", ItemCost = 50},
                    new CustomerRequestType.CoverItem() { ItemName = "engine", ItemCost = 20},
                    new CustomerRequestType.CoverItem() { ItemName = "contents", ItemCost = 30},
                    new CustomerRequestType.CoverItem() { ItemName = "doors", ItemCost = 15},
                }
            };
            
            
            var config = new InsurerConfigurationType()
            {
                InsurerRates = new List<InsurerConfigurationType.Insurer>()
                {
                    new InsurerConfigurationType.Insurer() {Name = "insurer_a" , Parts = new List<string>() {"windows","contents"}},
                    new InsurerConfigurationType.Insurer() {Name = "insurer_b" , Parts = new List<string>() {"tires","contents"}},
                    new InsurerConfigurationType.Insurer() {Name = "insurer_c" , Parts = new List<string>() {"doors","engines"}},
                }
            };


            var sut = new EngineQuoteService() as IEngineQuoteService;


            var myQuotes =  sut.GetQuotes(req, config);
            

            Assert.Equal(8, myQuotes[0].Price);
            Assert.Equal((decimal) 7.5 ,myQuotes[1].Price );

        }
    }
}