using SWCCorp.BLL;
using SWCCorp.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorp.Workflow
{
    public class RemoveOrderWorkflow
    {
        OrderManager manager;
        public RemoveOrderWorkflow(OrderManager mgr)
        {
            manager = mgr;
        }
        public void Execute()
        {
            
            Console.Clear();
            Console.WriteLine("Removing an Order");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~");
            DateTime date;
            Console.WriteLine("Enter the order date please. Example 01/12/2020: ");
            string inputDate = Console.ReadLine();
            DateTime.TryParse(inputDate, out date);
            Console.WriteLine("Enter the order number please.");
            string orderNum = Console.ReadLine();
            int.TryParse(orderNum, out int orderNumber);
            OrderLookupResponse allResponse = manager.LookupOrder(date, orderNumber);
            if (allResponse.Success)
            {
                ConsoleIO.DisplayOrderDetails(allResponse.order);
            }
            else
            {
                Console.WriteLine("There are no orders in that day. Press enter to continue");
                Console.ReadKey();
                return;
            }
            
            
            Console.WriteLine("Are you sure you want to delete this order? y/n");
            string answer = Console.ReadLine().ToLower();
            if (answer == "y")
            {
                DeleteOrderResponse response = manager.OrderDelete(date, orderNumber);
                Console.WriteLine("Your order has been deleted");
                    
            }
            else if (answer == "n")
            {
                Console.WriteLine("Order delete has been canceled");
            }
            else
            {
                Console.WriteLine("An error has occured: ");
                Console.WriteLine(allResponse.Message);
            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
            
        }
    }
}
