using System.Collections.Generic;
using SmartPhoneShop.Entity;

namespace SmartPhoneShop.Core.DomainService
{
    public interface IOrderRepository
    {
        Order CreateOrder(Order createdOrder);

        List<Order> GetAllOrder();

        Order GetOrderById(int id);

        Order UpdateOrder(Order updatedOrder);

        Order DeleteOrder(int id);
    }
}