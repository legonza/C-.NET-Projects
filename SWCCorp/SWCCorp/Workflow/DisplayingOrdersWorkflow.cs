using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCCorp.BLL;
using SWCCorp.Models;
using SWCCorp.Models.Responses;

namespace SWCCorp.Workflow
{
    public class DisplayingOrdersWorkflow
    {
        OrderManager manager;
        public DisplayingOrdersWorkflow(OrderManager mgr)
        {
            manager = mgr;
        }
        public void Execute()
       {
           
            
            Console.Clear();
            Console.WriteLine("Display an Order");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~");
            DateTime date;
            Console.WriteLine("Enter the order date please. Example 01/12/2020: ");
            string input = Console.ReadLine();
            DateTime.TryParse(input, out date);
            RetriveAllOrdersResponse response = manager.LookupAllOrders(date);
            if (response.Success)
            {
                if(response.orders.Count == 0)
                {
                    Console.WriteLine("There are no orders for that date.");
                }
                foreach (Order ord in response.orders)
                {
                    ConsoleIO.DisplayOrderDetails(ord);
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
       }
    }
}
