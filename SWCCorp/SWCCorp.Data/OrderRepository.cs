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
    public class OrderRepository : IOrderRepository
    {
        
        public static Order MapToOrder(string row)
        {
            string[] values = row.Split('~');
            Order ord = new Order();
            int.TryParse(values[0], out int value);
            ord.OrderNumber = value;
            ord.CustomerName = values[1];
            ord.State = values[2];
            decimal.TryParse(values[3], out decimal value1);
            ord.TaxRate = value1;
            ord.ProductType = values[4];
            decimal.TryParse(values[5], out decimal value2);
            ord.Area = value2;
            decimal.TryParse(values[6], out decimal value3);
            ord.CostPerSquareFoot = value3;
            decimal.TryParse(values[7], out decimal value4);
            ord.LaborCostPerSquareFoot = value4;
            decimal.TryParse(values[8], out decimal value5);
            ord.MaterialCost = value5;
            decimal.TryParse(values[9], out decimal value6);
            ord.LaborCost = value6;
            decimal.TryParse(values[10], out decimal value7);
            ord.Tax = value7;
            decimal.TryParse(values[11], out decimal value8);
            ord.Total = value8;
            return ord;
        }
        public static string MapToRow(Order ord)
        {
            string returnValue = "";
            returnValue += ord.OrderNumber + "~";
            returnValue += ord.CustomerName + "~";
            returnValue += ord.State + "~";
            returnValue += ord.TaxRate + "~";
            returnValue += ord.ProductType + "~";
            returnValue += ord.Area + "~";
            returnValue += ord.CostPerSquareFoot + "~";
            returnValue += ord.LaborCostPerSquareFoot + "~";
            returnValue += ord.MaterialCost + "~";
            returnValue += ord.LaborCost + "~";
            returnValue += ord.Tax + "~";
            returnValue += ord.Total;
            return returnValue;
        }
        public List<Order> GetAllOrders(DateTime date)
        {
            List<Order> orders = new List<Order>();
            string path = $"C:\\Users\\gonza\\source\\repos\\SWCCorp\\SWCCorp\\bin\\Debug\\Orders_{date.Month}{date.Day}{date.Year}.txt";
            bool fileExist = File.Exists(path);
            if (fileExist)
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line = string.Empty;
                    sr.ReadLine();
                    while ((line = sr.ReadLine()) != null)
                    {
                        Order ord = MapToOrder(line);
                        ord.Date = date;
                        orders.Add(ord);
                    }
                }

            }
            return orders;
        }
        public static List<Order> SaveAllOrders(List<Order> orders)
        {
            if (orders.Count != 0)
            {
                DateTime theDate = orders.First(o => o == o).Date;
                string path = $"C:\\Users\\gonza\\source\\repos\\SWCCorp\\SWCCorp\\bin\\Debug\\Orders_{theDate.Month}{theDate.Day}{theDate.Year}.txt";
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("OrderNumber~Name~State~TaxRate~ProductType~Area~CostPerSquareFoot~LaborCostPerSquareFoot~MaterialCost~LaborCost~Tax~Total");
                    foreach (Order ord in orders)
                    {
                        sw.WriteLine(MapToRow(ord));
                    }
                }
            }
        
            return orders;
        }

        public Order UpdateOrder(Order order)
        {
            List<Order> orders = GetAllOrders(order.Date);
            Order ord = orders.FirstOrDefault(o => o.OrderNumber == order.OrderNumber);
            DeleteOrder(order.Date, order.OrderNumber);
            SaveOrder(order);
            return order;
        }

        public Order DeleteOrder(DateTime date, int OrderNumber)
        {
            List<Order> orders = GetAllOrders(date);
            foreach (Order ord in orders)
            {
                if (date == ord.Date && OrderNumber == ord.OrderNumber)
                {
                    orders.Remove(ord);
                    SaveAllOrders(orders);
                    if(orders.Count == 0)
                    {
                        string path = $"C:\\Users\\gonza\\source\\repos\\SWCCorp\\SWCCorp\\bin\\Debug\\Orders_{date.Month}{date.Day}{date.Year}.txt";
                        File.Delete(path);
                    }
                    return ord;
                }
            }
            return null;
        }

        public Order LoadOrder(DateTime date, int OrderNumber)
        {
            List<Order> orders = GetAllOrders(date);
            Order ord = orders.FirstOrDefault(o => o.Date == date);
            return ord;
        }

        public void SaveOrder(Order ord)
        {
            List<Order> orders = GetAllOrders(ord.Date);
            if(orders.Count() == 0)
            {
                ord.OrderNumber = 1;
            }
            else if(ord.OrderNumber == 0)
            {
                ord.OrderNumber = orders.Max(o => o.OrderNumber) + 1;
            }
            orders.Add(ord);
            SaveAllOrders(orders);
        }
    }
}
