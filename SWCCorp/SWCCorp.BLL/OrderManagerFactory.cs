using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using SWCCorp.Data;

namespace SWCCorp.BLL
{
    public class OrderManagerFactory
    {
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "Test":
                    return new OrderManager(new OrderTestRepository());
                case "Program":
                    return new OrderManager(new OrderRepository());
                default:
                    throw new Exception("Mode value in app config not valid");
                   
            }
        }
    }
}
