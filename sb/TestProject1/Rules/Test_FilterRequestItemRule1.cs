using System.Linq;
using sb.ConsoleApp1.Services.Rules;
using TestProject1.Common;
using Xunit;

namespace TestProject1.Rules
{
    public class Test_FilterRequestItemRule1
    {
        [Fact]
        public void Test_FilterRequestItemRule1_Given_sampleData_Should_Return_only_3_Items()
        {
            var customerRequest = DataGenerator_sample1.GenerateCustomerRequest();
            
            var sut = new FilterRequestItemsRule1() as IFilterRequestItemsRule;
            var result = sut.FilterRequestItems(customerRequest.covers);

            Assert.Equal(3 , result.Count);
        }
        
        [Fact]
        public void Test_FilterRequestItemRule1_Given_sampleData_Expect_firstItemCost_Equal_50()
        {
            var customerRequest = DataGenerator_sample1.GenerateCustomerRequest();
            
            var sut = new FilterRequestItemsRule1() as IFilterRequestItemsRule;
            var result = sut.FilterRequestItems(customerRequest.covers);

            Assert.Equal(50 , result[0].ItemCost);
        }
        
       
        
    }
}