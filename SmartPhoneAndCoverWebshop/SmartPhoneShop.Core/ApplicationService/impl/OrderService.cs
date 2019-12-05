using System;
using System.Collections.Generic;
using System.IO;
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
            if (createdOrder.User == null || createdOrder.User.Id <= 0)
            {
                throw new InvalidDataException("Must have a User");
            }

            if (_userRepo.GetUserById(createdOrder.User.Id) == null)
            {
                throw new InvalidDataException("User not found");
            }

            if (createdOrder.OrderDate == null)
            {
                throw new InvalidDataException("Must have a Order Date");
            }

            if (createdOrder.DeliveryDate <= DateTime.MinValue)
            {
                throw new InvalidDataException("Must have a Delivery Date");
            }
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