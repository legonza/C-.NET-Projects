using SWCCorp.Data;
using SWCCorp.Models;
using SWCCorp.Models.Interfaces;
using SWCCorp.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorp.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepository;
        private IOrderProductRepository _productRepository;
        private IOrderTaxRepository _taxRepository;
        private List<Product> _products;
        private List<Tax> _taxes;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = new ProductRepository();
            _taxRepository = new TaxRepository();
            _products = _productRepository.GetInfo();
            _taxes = _taxRepository.GetTaxInfo();
        }
        public OrderLookupResponse LookupOrder(DateTime date, int OrderNumber)
        {
            OrderLookupResponse response = new OrderLookupResponse();
            response.order = _orderRepository.LoadOrder(date, OrderNumber);
            if(response.order == null)
            {
                response.Success = false;
                response.Message = $"{date} is not a valid order.";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }
        public RetriveAllOrdersResponse LookupAllOrders(DateTime date)
        {
            RetriveAllOrdersResponse response = new RetriveAllOrdersResponse();
            response.orders = _orderRepository.GetAllOrders(date);
            if(response.orders == null)
            {
                response.Success = false;
                response.Message = "Error: Order does not exist";
                return response;
            }
            else
            {
                response.Success = true;
            }
            return response;
        }
        public CreateOrderResponse CreateOrder(Order order)
        {
            CreateOrderResponse response = new CreateOrderResponse();
            response.order = order;
            _orderRepository.SaveOrder(order);
            response.Success = true;
            return response;
        }
        public UpdateEditOrderResponse OrderUpdate(DateTime date, int OrderNumber, string CustomerName, string State, string ProductType, decimal Area)
        {
            UpdateEditOrderResponse respose = new UpdateEditOrderResponse();
            CreateOrderResponse calculation = Calculation(date, CustomerName, State, ProductType, Area);
            calculation.order.OrderNumber = OrderNumber;

            respose.order = _orderRepository.UpdateOrder(calculation.order);
            if(respose.order == null)
            {
                respose.Success = false;
                respose.Message = "Cannot find that order";
                return respose;
            }
            else
            {
                respose.Success = true;

                
            }
          
            return respose;
        }
        public DeleteOrderResponse OrderDelete(DateTime Date, int OrderNumber)
        {
            DeleteOrderResponse response = new DeleteOrderResponse();
            response.order = _orderRepository.DeleteOrder(Date, OrderNumber);
            if(response.order == null)
            {
                response.Success = false;
                response.Message = $"Error: {Date} is not an existing order";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }
        public CreateOrderResponse Calculation(DateTime Date, string CustomerName, string State,string ProductType, decimal Area)
        {
            CreateOrderResponse response = new CreateOrderResponse();
            response.order = new Order();
            if(Date == DateTime.Today)
            {
                response.Success = false;
                response.Message = $"Error: The {Date} has to be in the future";
                return response;
            }
            if(!CustomerName.All(c => char.IsLetterOrDigit(c) || c == ',' || c == '-'))
            {
                response.Success = false;
                response.Message = "Not a valid name character";
                return response;
            }
            if (_taxes.FirstOrDefault(a=> a.StateName.ToLower()  == State) == null)
            {
                response.Success = false;
                response.Message = "That was not a valid state";
                return response;
            }
            if (_products.FirstOrDefault(p => p.ProductType.ToLower() == ProductType) == null)
            {
                response.Success = false;
                response.Message = "We do not sell that product";
                return response;
            }
            if (Area < 100)
            {
                response.Success = false;
                response.Message = $"{Area} must be a minimun of 100 square feet";
                return response;
            }

            response.Success = true;
            response.order.Date = Date;
            response.order.CustomerName = CustomerName;
            response.order.State = State;
            decimal taxRate = _taxes.FirstOrDefault(a => a.StateName.ToLower() == State).TaxRate;
            response.order.TaxRate = taxRate; 
            response.order.ProductType = ProductType;
            response.order.Area = Area;
            decimal costPerSquareFoot = _products.FirstOrDefault(p => p.ProductType.ToLower() == ProductType).CostPerSquareFoot;
            response.order.CostPerSquareFoot = costPerSquareFoot;
            decimal laborCostPerSquareFoot = _products.FirstOrDefault(l => l.ProductType.ToLower() == ProductType).LaborCostPerSquareFoot;
            response.order.LaborCostPerSquareFoot = laborCostPerSquareFoot; 
            

            response.order.MaterialCost = response.order.Area * costPerSquareFoot;
            response.order.LaborCost = response.order.Area * laborCostPerSquareFoot;
            response.order.Tax = (response.order.MaterialCost + response.order.LaborCost) * (taxRate / 100);
            response.order.Total = response.order.MaterialCost + response.order.LaborCost + response.order.Tax;

            return response;
        }
    }
}
