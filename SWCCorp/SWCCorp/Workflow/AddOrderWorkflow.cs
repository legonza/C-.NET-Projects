using SWCCorp.BLL;
using SWCCorp.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SWCCorp.Workflow
{
    public class AddOrderWorkflow
    {
        OrderManager manager;
        public AddOrderWorkflow(OrderManager mgr)
        {
            manager = mgr;
        }
        public void Execute()
        {
            
            Console.Clear();
            Console.WriteLine("Adding an order");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~");
            DateTime date;
            
            Console.WriteLine("When do you want it delived? Example 03/01/2020: ");
            string input = Console.ReadLine();
            DateTime.TryParse(input, out date);
            while(date <= DateTime.Now)
            {
                Console.WriteLine("Order date needs to be a future date");
                Console.WriteLine("Please enter a valid date.");
                input = Console.ReadLine();
                DateTime.TryParse(input, out date);
            }
            Console.WriteLine("Please enter your name");
            string CustomerName = Console.ReadLine();
            Console.WriteLine("What state would you like the service for? We service Ohio, Pennsylvania, Michigan, and Indiana");
            string state = Console.ReadLine().ToLower();
            while(state != "ohio" && state != "pennsylvania" && state != "michigan" && state != "indiana")
            {
                Console.WriteLine("Sorry we do not service that state");
                Console.WriteLine("please enter a valid state. We service Ohio, Pennsylvania, Michigan, and Indiana");
                state = Console.ReadLine().ToLower();
            }
            Console.WriteLine("What product type are you looking for? We offer Carpet, Laminate, Tile, Wood");
            string productType = Console.ReadLine().ToLower();
            while (productType != "carpet" && productType != "laminate" && productType != "tile" && productType != "wood")
            {
                Console.WriteLine("We do not offer that product.");
                Console.WriteLine("Please enter one of the products we offer. We offer Carpet, Laminate, Tile, Wood");
                productType = Console.ReadLine().ToLower();
            }
            Console.WriteLine("Enter the area (square footage) that you need. Minimun of 100 square feet please");
            string areaNum = Console.ReadLine();
            decimal.TryParse(areaNum, out decimal area);
            while (area < 100)
            {
                Console.WriteLine("Area square footage needed to be 100 square footage or more.");
                Console.WriteLine("Enter the area square footage minumun of 100");
                areaNum = Console.ReadLine();
                decimal.TryParse(areaNum, out area);
            }
            CreateOrderResponse response = manager.Calculation(date, CustomerName, state, productType, area);
            ConsoleIO.DisplayOrderDetails(response.order);
            if(response.Success)
            {
                Console.WriteLine("Do you want to place the Order? y/n");
                string answer = Console.ReadLine().ToLower();
                if(answer == "y")
                {
                    CreateOrderResponse newResponse = manager.CreateOrder(response.order);
                    Console.WriteLine("Your order has been created and added");
                    
                }
                else if (answer == "n")
                {
                    Console.WriteLine("Order has been canceled");
                }
                else
                {
                    response.Message = "An error has occured: ";
                    Console.WriteLine(response.Message);
                }
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
            }
        }
    }
}
