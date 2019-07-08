using SWCCorp.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorp.Models.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders(DateTime date);
        Order UpdateOrder(Order order);
        Order DeleteOrder(DateTime date, int OrderNumber);
        Order LoadOrder(DateTime date, int OrderNumber);
        void SaveOrder(Order order);
    }
}
