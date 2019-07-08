using SWCCorp.BLL;
using SWCCorp.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorp.Workflow
{
    public class UpdateOrderWorkflow
    {
        OrderManager manager;
        public UpdateOrderWorkflow(OrderManager mgr)
        {
            manager = mgr;
        }
        public void Execute()
        {
            
            string CustomerName = "";
            string State = "";
            string ProductType = "";
            decimal Area = 0;
            Console.Clear();
            Console.WriteLine("Edit your Order");
            Console.WriteLine("~~~~~~~~~~~~~~~~~");
            DateTime date;
            while (true)
            {
                Console.WriteLine("Enter the order date please. Example 01/12/2020: ");
                string inputDate = Console.ReadLine();
                if (DateTime.TryParse(inputDate, out date))
                {
                    break;
                }
                Console.WriteLine("No orders with that date");
            }
            Console.WriteLine("Enter the order number please.");
            string orderNum = Console.ReadLine();
            int.TryParse(orderNum, out int OrderNumber);
            OrderLookupResponse allResponse = manager.LookupOrder(date, OrderNumber);
            
            if (allResponse.Success)
            {
                ConsoleIO.DisplayOrderDetails(allResponse.order);
            }
            else
            {
                Console.WriteLine("There are no orders in that day. Press enter to continue.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Name: " + allResponse.order.CustomerName + " enter new name to update order or press enter to continue");
            string name = Console.ReadLine().ToLower();
            if(name == string.Empty)
            {
                CustomerName = allResponse.order.CustomerName;
            }
            else
            {
                CustomerName = name;
            }
            Console.WriteLine("State: " + allResponse.order.State + " enter a new state to update order.");
            Console.WriteLine("We service Ohio, Pennsylvania, Michigan, and Indiana or press enter to continue");
            string state = Console.ReadLine().ToLower();
            while (state != "ohio" && state != "pennsylvania" && state != "michigan" && state != "indiana" && state != string.Empty)
            {
                Console.WriteLine("Sorry we do not service that state");
                Console.WriteLine("please enter a valid state. We service Ohio, Pennsylvania, Michigan, and Indiana");
                state = Console.ReadLine().ToLower();
            }
            if (state == string.Empty)
            {
                State = allResponse.order.State;
            }
            else
            {
                State = state;
            }
            Console.WriteLine("Product Type: " + allResponse.order.ProductType + " enter a new product type to update the order.");
            Console.WriteLine("The products we offer are Carpet, Laminate, Tile, and Wood or press enter to continue");
            string productType = Console.ReadLine().ToLower();
            while (productType != "carpet" && productType != "laminate" && productType != "tile" && productType != "wood" && productType != string.Empty)
            {
                Console.WriteLine("We do not offer that product.");
                Console.WriteLine("Please enter one of the products we offer. We offer Carpet, Laminate, Tile, Wood");
                productType = Console.ReadLine().ToLower();
            }
            if (productType == string.Empty)
            {
                ProductType = allResponse.order.ProductType;
            }
            else
            {
                ProductType = productType;
            }
            Console.WriteLine("Area: " + allResponse.order.Area + " enter a new area square footage to update the order, minimun of 100 square foot or press enter to continue");
            string areaSquare = Console.ReadLine();
            decimal area = 0;
            decimal.TryParse(areaSquare, out area);
            while (area < 100)
            {
                if(areaSquare == string.Empty)
                {
                    break;
                }
                Console.WriteLine("Area square footage needed to be 100 square footage or more.");
                Console.WriteLine("Enter the area square footage minumun of 100");
                areaSquare = Console.ReadLine();
                decimal.TryParse(areaSquare, out area);
            }
            if (areaSquare == string.Empty)
            {
                Area = allResponse.order.Area;
            }
            else
            {
                Area = area;

            }
            
            CreateOrderResponse response = manager.Calculation(date, CustomerName, State, ProductType, Area);
            ConsoleIO.DisplayOrderDetails(response.order);
            Console.WriteLine("Do you want to update the Order? y/n");
            string answer = Console.ReadLine().ToLower();
            if (answer == "y")
            {
                UpdateEditOrderResponse update = manager.OrderUpdate(date, OrderNumber, CustomerName, State, ProductType, Area);
                Console.WriteLine("Your order has been created and added");
                ConsoleIO.DisplayOrderDetails(update.order);

            }
            else if (answer == "n")
            {
                Console.WriteLine("No changes have been made");
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
