using SWCCorp.BLL;
using SWCCorp.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorp
{
    public class Menu
    {
        public static void Start()
        {
            OrderManager manager = OrderManagerFactory.Create();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("SWC Corp Flooring Program");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("1. Display Orders");
                Console.WriteLine("2. Add an Order");
                Console.WriteLine("3. Edit an Order");
                Console.WriteLine("4. Remove an Order");
                Console.WriteLine("\nQ to Quit");
                Console.WriteLine("\nEnter Your Selection: ");

                string userInput = Console.ReadLine().ToLower();

                switch (userInput)
                {
                    case "1":
                        DisplayingOrdersWorkflow displayOrder = new DisplayingOrdersWorkflow(manager);
                        displayOrder.Execute();
                        break;
                    case "2":
                        AddOrderWorkflow addOrder = new AddOrderWorkflow(manager);
                        addOrder.Execute();
                        break;
                    case "3":
                        UpdateOrderWorkflow updateOrder = new UpdateOrderWorkflow(manager);
                        updateOrder.Execute();
                        break;
                    case "4":
                        RemoveOrderWorkflow removeOrder = new RemoveOrderWorkflow(manager);
                        removeOrder.Execute();
                        break;
                    case "Q":
                        return;
                }
            }
        }
    }
}
