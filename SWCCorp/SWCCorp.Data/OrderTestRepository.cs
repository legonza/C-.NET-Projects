using SWCCorp.Models;
using SWCCorp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SWCCorp.Data
{
    public class OrderTestRepository : IOrderRepository
    {
        List<Order> orders = new List<Order>() {

        new Order()
        {
            Date = new DateTime(2020, 01, 01),
            OrderNumber = 1,
            CustomerName = "lisa",
            State = "ohio",
            TaxRate = 6.25M,
            ProductType = "wood",
            Area = 100.00M,
            CostPerSquareFoot = 5.15M,
            LaborCostPerSquareFoot = 4.75M,
            MaterialCost = 515.00M,
            LaborCost = 475.00M,
            Tax = 61.88M,
            Total = 1051.88M


        },
        new Order()
        {
            Date = new DateTime(2020, 01, 01),
            OrderNumber = 2,
            CustomerName = "luis",
            State = "ohio",
            TaxRate = 6.25M,
            ProductType = "carpet",
            Area = 100.00M,
            CostPerSquareFoot = 2.25M,
            LaborCostPerSquareFoot = 2.10M,
            MaterialCost = 225.00M,
            LaborCost = 210.00M,
            Tax = 61.88M,
            Total = 496.88M
        }
        };
        public List<Order> GetAllOrders(DateTime date)
        {
            return orders;
        }
        public Order UpdateOrder(Order order)
        {
            DeleteOrder(order.Date, order.OrderNumber);
            SaveOrder(order);
            return order;

        }

        public Order DeleteOrder(DateTime date, int OrderNumber)
        {
            foreach(Order ord in orders)
            {
                if(date == ord.Date && OrderNumber == ord.OrderNumber)
                {
                    orders.Remove(ord);
                    return ord;
                }
            }
            return null;
        }

        public Order LoadOrder(DateTime date, int OrderNumber)
        {
            List<Order> orders = GetAllOrders(date);
            Order ord = orders.FirstOrDefault(o => o.Date == date && OrderNumber == o.OrderNumber);
            return ord;
        }
        public void SaveOrder(Order ord)
        {
            List<Order> orders = GetAllOrders(ord.Date);
            if (orders.Count() == 0)
            {
                ord.OrderNumber = 1;
            }
            else if (ord.OrderNumber == 0)
            {
                ord.OrderNumber = orders.Max(o => o.OrderNumber) + 1;
            }
            orders.Add(ord);
        }

        
    }
}
