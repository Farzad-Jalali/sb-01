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
                covers = new List<CustomerRequestType.CarItemCoverCost>()
                {
                    new CustomerRequestType.CarItemCoverCost() {ItemName = "tires", ItemCost = 10},
                    new CustomerRequestType.CarItemCoverCost() {ItemName = "windows", ItemCost = 50},
                    new CustomerRequestType.CarItemCoverCost() {ItemName = "engine", ItemCost = 20},
                    new CustomerRequestType.CarItemCoverCost() {ItemName = "contents", ItemCost = 30},
                    new CustomerRequestType.CarItemCoverCost() {ItemName = "doors", ItemCost = 15},
                }
            };


            var config = new InsurerConfigurationType()
            {
                InsurerRates = new List<InsurerConfigurationType.Insurer>()
                {
                    new InsurerConfigurationType.Insurer()
                    {
                        Name = "insurer_a",
                        CarPartsCovered = new List<InsurerConfigurationType.Insurer.CarPartItem>()
                        {
                            new InsurerConfigurationType.Insurer.CarPartItem() {ItemName = "windows"},
                            new InsurerConfigurationType.Insurer.CarPartItem() {ItemName = "contents"},
                        }
                    },
                    new InsurerConfigurationType.Insurer()
                    {
                        Name = "insurer_b",
                        CarPartsCovered = new List<InsurerConfigurationType.Insurer.CarPartItem>()
                        {
                            new InsurerConfigurationType.Insurer.CarPartItem() {ItemName = "tires"},
                            new InsurerConfigurationType.Insurer.CarPartItem() {ItemName = "contents"},
                        }
                    },
                    new InsurerConfigurationType.Insurer()
                    {
                        Name = "insurer_c",
                        CarPartsCovered = new List<InsurerConfigurationType.Insurer.CarPartItem>()
                        {
                            new InsurerConfigurationType.Insurer.CarPartItem() {ItemName = "doors"},
                            new InsurerConfigurationType.Insurer.CarPartItem() {ItemName = "engines"},
                        }
                    },
                }
            };


            var sut = new EngineQuoteService() as IEngineQuoteService;


            var myQuotes = sut.GetQuotes(req, config);


            Assert.Equal(8, myQuotes[0].Price);
            Assert.Equal((decimal) 7.5, myQuotes[1].Price);
        }
    }
}