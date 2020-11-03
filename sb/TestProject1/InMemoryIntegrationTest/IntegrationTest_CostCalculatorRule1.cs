using sb.ConsoleApp1.Services.Rules;
using TestProject1.Common;
using Xunit;

namespace TestProject1.InMemoryIntegrationTest
{
    public class IntegrationTest_CostCalculatorRule1
    {
        [Theory]
        [InlineData("insurer_a", 8)]
        [InlineData("insurer_b", 7.5)]
        [InlineData("insurer_c", 6)]
        public void IntegrationTest_CostCalculatorRule1_Given_SampleData_should_expectedCost_beEqual_with_actualCost(string insurerName,
            decimal expectedCost)
        {
            var customerRequest = DataGenerator_sample1.GenerateCustomerRequest();
            var insurer = DataGenerator_sample1.GetInsurer(insurerName);
            var matchingEngine = new MatchingEngineRule1() as IMatchingEngineRule;
            var filterRequestItems = new FilterRequestItemsRule1() as IFilterRequestItemsRule;
           
            var sut = new CostCalculatorRule1(matchingEngine , filterRequestItems) as ICostCalculatorRule;
            
           var actualCost = sut.GetCost(customerRequest.covers, insurer);

           Assert.Equal(expectedCost,actualCost);
        }
    }
}