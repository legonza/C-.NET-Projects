using SWCCorp.Models;
using SWCCorp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorp.Data
{
    public class ProductRepository : IOrderProductRepository
    {
        List<Product> products = new List<Product>();
        public static Product MapToProduct(string row)
        {
            string[] values = row.Split('~');
            Product prod = new Product();
            prod.ProductType = values[0];
            decimal.TryParse(values[1], out decimal value);
            prod.CostPerSquareFoot = value;
            decimal.TryParse(values[2], out decimal value1);
            prod.LaborCostPerSquareFoot = value1;
            return prod;
        }
        public List<Product> GetInfo()
        {
            using (StreamReader sr = new StreamReader("C:\\Users\\gonza\\source\\repos\\SWCCorp\\SWCCorp\\bin\\Debug\\Products.txt"))
            {
                string line = string.Empty;
                sr.ReadLine();
                while((line = sr.ReadLine()) != null)
                {
                    Product prod = MapToProduct(line);
                    products.Add(prod);
                }

            }
            return products;
        }

    }
}
