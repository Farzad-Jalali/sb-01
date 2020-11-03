using System.Linq;
using sb.ConsoleApp1.Services.Rules;
using TestProject1.Common;
using Xunit;

namespace TestProject1.Rules
{
    public class Test_MatchingEngineRule1
    {
        [Theory]
        [InlineData("insurer_a", "windows")]
        [InlineData("insurer_b", "contents")]
        [InlineData("insurer_c", "engine")]
        public void
            Test_MatchingEngineRule1_given_TheInsurerName_with_sample_Data_TheResult_should_contains_theExpected_itemName(
                string insurerName, string expectedItemName)
        {
            var items = DataGenerator_sample1.GetTop3CarItemCoverCost();
            var insurer = DataGenerator_sample1.GetInsurer(insurerName);
            var sut = new MatchingEngineRule1() as IMatchingEngineRule;
            var matched = sut.GetMatchedItems(items, insurer);

            Assert.Contains(expectedItemName , matched.Select(item => item.ItemName));
        }
        
        
        [Theory]
        [InlineData("insurer_a", "invalidItemName")]
        [InlineData("insurer_b", "invalidItemName")]
        [InlineData("insurer_c", "invalidItemName")]
        public void
            Test_MatchingEngineRule1_given_TheInsurerName_with_sample_Data_TheResult_should_NOT_contains_theExpected_itemName(
                string insurerName, string expectedItemName)
        {
            var items = DataGenerator_sample1.GetTop3CarItemCoverCost();
            var insurer = DataGenerator_sample1.GetInsurer(insurerName);
            var sut = new MatchingEngineRule1() as IMatchingEngineRule;
            var matched = sut.GetMatchedItems(items, insurer);
            
            Assert.DoesNotContain(expectedItemName , matched.Select(item => item.ItemName));
        }
    }
}