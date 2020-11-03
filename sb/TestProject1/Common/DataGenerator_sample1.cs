using System.Collections.Generic;
using System.Linq;
using sb.ConsoleApp1.Domain;

namespace TestProject1.Common
{
    public  class DataGenerator_sample1
    {

        public static InsurerConfigurationType.Insurer GetInsurer(string name)
        {
            return GenerateInsurerConfig().InsurerRates.Where(x => x.Name == name).ToList()[0];
        }

        public static List<CustomerRequestType.CarItemCoverCost> GetTop3CarItemCoverCost()
        {
            return GenerateCustomerRequest().covers.OrderByDescending(x => x.ItemCost).Take(3).ToList();
        }

        public static  CustomerRequestType GenerateCustomerRequest() => new CustomerRequestType()
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
        
        
        
        public static  InsurerConfigurationType GenerateInsurerConfig() => new InsurerConfigurationType()
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
                        new InsurerConfigurationType.Insurer.CarPartItem() {ItemName = "engine"},
                    }
                },
            }
        };
        
        
    }
}