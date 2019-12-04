using System.Collections.Generic;
using SmartPhoneShop.Core.DomainService;
using SmartPhoneShop.Entity;

namespace SmartPhoneShop.Core.ApplicationService.impl
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepo;
        private readonly IUserRepository _userRepo;

        public OrderService(IOrderRepository orderRepo, IUserRepository userRepo)
        {
            _orderRepo = orderRepo;
            _userRepo = userRepo;
        }
        public Order NewOrder()
        {
            return new Order();
        }

        public Order CreateOrder(Order createdOrder)
        {
            return _orderRepo.CreateOrder(createdOrder);
        }

        public List<Order> GetAllOrder()
        {
            return _orderRepo.GetAllOrder();
        }

        public Order GetOrderById(int id)
        {
            return _orderRepo.GetOrderById(id);
        }

        public Order UpdateOrder(Order updatedOrder)
        {
            return _orderRepo.UpdateOrder(updatedOrder);
        }

        public Order DeleteOrder(int id)
        {
            return _orderRepo.DeleteOrder(id);
        }
    }
}