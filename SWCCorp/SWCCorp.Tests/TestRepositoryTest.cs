using NUnit.Framework;
using SWCCorp.BLL;
using SWCCorp.Models;
using SWCCorp.Models.Interfaces;
using SWCCorp.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorp.Tests
{
    [TestFixture]
    public class TestRepositoryTest
    {
        [TestCase(2020, 01, 01, "lisa", 5, "ohio", 6.25, "wood", 100.00, 5.15, 4.75, 515.00, 475.00, 61.88, 1051.88, false)]//wrong order number
        [TestCase(2020, 01, 01, "lisa", 1, "ohio", 6.25, "wood", 100.00, 5.15, 4.75, 515.00, 475.00, 61.88, 1051.88, true)]
        public void TestlookupReponse(int year, int month, int day , string customerName, int orderNumber, string state, decimal taxRate, string productType, decimal area,
            decimal costPerSquareFoot, decimal laborCostPerSquareFoot, decimal materialCost, decimal laborCost, decimal tax, decimal total, bool expectedResult)
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order ord = new Order();
            ord.Date = new DateTime(year, month, day);
            ord.CustomerName = customerName;
            ord.OrderNumber = orderNumber;
            ord.State = state;
            ord.TaxRate = taxRate;
            ord.ProductType = productType;
            ord.Area = area;
            ord.CostPerSquareFoot = costPerSquareFoot;
            ord.LaborCostPerSquareFoot = laborCostPerSquareFoot;
            ord.MaterialCost = materialCost;
            ord.LaborCost = laborCost;
            ord.Tax = tax;
            ord.Total = total;
            OrderLookupResponse response = manager.LookupOrder(ord.Date, orderNumber);
            if (response.Success)
            {
                Assert.IsNotNull(response.order);
                Assert.AreEqual(response.order.ProductType, productType);
                Assert.AreEqual(response.order.Area, area);
            }
            Assert.AreEqual(expectedResult, response.Success);
        }
        [TestCase(2020, 01, 01, "lisa", 1, "ohio", 6.25, "wood", 100.00, 5.15, 4.75, 515.00, 475.00, 61.88, 1051.88, true)]
        public void TestAddResponse(int year, int month, int day, string customerName, int orderNumber, string state, decimal taxRate, string productType, decimal area,
            decimal costPerSquareFoot, decimal laborCostPerSquareFoot, decimal materialCost, decimal laborCost, decimal tax, decimal total, bool expectedResult)
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order ord = new Order();
            ord.Date = new DateTime(year, month, day);
            ord.CustomerName = customerName;
            ord.OrderNumber = orderNumber;
            ord.State = state;
            ord.TaxRate = taxRate;
            ord.ProductType = productType;
            ord.Area = area;
            ord.CostPerSquareFoot = costPerSquareFoot;
            ord.LaborCostPerSquareFoot = laborCostPerSquareFoot;
            ord.MaterialCost = materialCost;
            ord.LaborCost = laborCost;
            ord.Tax = tax;
            ord.Total = total;
            CreateOrderResponse response = manager.CreateOrder(ord);
            if (response.Success)
            {
                Assert.IsNotNull(response.order);
                Assert.AreEqual(response.order.CustomerName, customerName);
                Assert.AreEqual(response.order.Date, ord.Date);
                Assert.AreEqual(response.order.State, state);
                Assert.AreEqual(response.order.Area, area);
            }
            Assert.AreEqual(expectedResult, response.Success);
        }
        [TestCase(2020, 01, 01, "luis", 2, "ohio", 6.25, "carpet", 100.00, 2.25, 2.10, 225.00, 210.00, 61.88, 496.88, true)]
        public void TestUpdateResponse(int year, int month, int day, string customerName, int orderNumber, string state, decimal taxRate, string productType, decimal area,
            decimal costPerSquareFoot, decimal laborCostPerSquareFoot, decimal materialCost, decimal laborCost, decimal tax, decimal total, bool expectedResult)
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order ord = new Order();
            ord.Date = new DateTime(year, month, day);
            ord.CustomerName = customerName;
            ord.OrderNumber = orderNumber;
            ord.State = state;
            ord.TaxRate = taxRate;
            ord.ProductType = productType;
            ord.Area = area;
            ord.CostPerSquareFoot = costPerSquareFoot;
            ord.LaborCostPerSquareFoot = laborCostPerSquareFoot;
            ord.MaterialCost = materialCost;
            ord.LaborCost = laborCost;
            ord.Tax = tax;
            ord.Total = total;
            UpdateEditOrderResponse response = manager.OrderUpdate(ord.Date, orderNumber, customerName, state, productType, area);//manager.Calculation(ord.Date, customerName, state, productType, area);
            if (response.Success)
            {
                Assert.IsNotNull(response.order);
                Assert.AreEqual(response.order.CustomerName, customerName);
                Assert.AreEqual(response.order.Date, ord.Date);
                Assert.AreEqual(response.order.State, state);
                Assert.AreEqual(response.order.Area, area);
            }
            Assert.AreEqual(expectedResult, response.Success);

        }
        [TestCase(2020, 01, 01, "luis", 2, "ohio", 6.25, "carpet", 100.00, 2.25, 2.10, 225.00, 210.00, 61.88, 496.88, true)]
        public void TestDeleteResponse(int year, int month, int day, string customerName, int orderNumber, string state, decimal taxRate, string productType, decimal area,
            decimal costPerSquareFoot, decimal laborCostPerSquareFoot, decimal materialCost, decimal laborCost, decimal tax, decimal total, bool expectedResult)
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order ord = new Order();
            ord.Date = new DateTime(year, month, day);
            ord.CustomerName = customerName;
            ord.OrderNumber = orderNumber;
            ord.State = state;
            ord.TaxRate = taxRate;
            ord.ProductType = productType;
            ord.Area = area;
            ord.CostPerSquareFoot = costPerSquareFoot;
            ord.LaborCostPerSquareFoot = laborCostPerSquareFoot;
            ord.MaterialCost = materialCost;
            ord.LaborCost = laborCost;
            ord.Tax = tax;
            ord.Total = total;
            DeleteOrderResponse response = manager.OrderDelete(ord.Date, orderNumber);
            if (response.Success)
            {
                Assert.IsNotNull(response.order);
                Assert.AreEqual(response.order.CustomerName, customerName);
                Assert.AreEqual(response.order.Date, ord.Date);
                Assert.AreEqual(response.order.State, state);
                Assert.AreEqual(response.order.Area, area);
            }
            Assert.AreEqual(expectedResult, response.Success);
        }
        [TestCase(2020, 01, 01, "Bob~~~", 1, "ohio", 6.25, "wood", 100.00, 5.15, 4.75, 515.00, 475.00, 61.88, 1051.88, false)]//wrong name with wrong characters
        [TestCase(2020, 01, 01, "lisa", 1, "florida", 6.25, "wood", 100.00, 5.15, 4.75, 515.00, 475.00, 61.88, 1051.88, false)]//state that we do not work with
        [TestCase(2020, 01, 01, "lisa", 1, "ohio", 6.25, "concrete", 100.00, 5.15, 4.75, 515.00, 475.00, 61.88, 1051.88, false)]//product type that we do not offer
        [TestCase(2020, 01, 01, "lisa", 1, "ohio", 6.25, "wood", 80.00, 5.15, 4.75, 515.00, 475.00, 61.88, 1051.88, false)]//area is less than 100 square feet
        [TestCase(2020, 01, 01, "lisa", 1, "ohio", 6.25, "wood", 100.00, 5.15, 4.75, 515.00, 475.00, 61.88, 1051.88, true)]
        public void TestCalculationResponse(int year, int month, int day, string customerName, int orderNumber, string state, decimal taxRate, string productType, decimal area,
            decimal costPerSquareFoot, decimal laborCostPerSquareFoot, decimal materialCost, decimal laborCost, decimal tax, decimal total, bool expectedResult)
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order ord = new Order();
            ord.Date = new DateTime(year, month, day);
            ord.CustomerName = customerName;
            ord.OrderNumber = orderNumber;
            ord.State = state;
            ord.TaxRate = taxRate;
            ord.ProductType = productType;
            ord.Area = area;
            ord.CostPerSquareFoot = costPerSquareFoot;
            ord.LaborCostPerSquareFoot = laborCostPerSquareFoot;
            ord.MaterialCost = materialCost;
            ord.LaborCost = laborCost;
            ord.Tax = tax;
            ord.Total = total;
            CreateOrderResponse response = manager.Calculation(ord.Date, customerName, state, productType, area);
            if (response.Success)
            {
                Assert.IsNotNull(response.order);
                Assert.AreEqual(response.order.CustomerName, customerName);
                Assert.AreEqual(response.order.Date, ord.Date);
                Assert.AreEqual(response.order.State, state);
                Assert.AreEqual(response.order.Area, area);
                Assert.AreEqual(response.order.ProductType, productType);
            }
            Assert.AreEqual(expectedResult, response.Success);
        }
    }
}
