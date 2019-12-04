using System.Collections.Generic;
using SmartPhoneShop.Entity;

namespace SmartPhoneShop.Core.ApplicationService
{
    public interface IOrderService
    {
        Order NewOrder();

        Order CreateOrder(Order createdOrder);

        List<Order> GetAllOrder();

        Order GetOrderById(int id);

        Order UpdateOrder(Order updatedOrder);

        Order DeleteOrder(int id);
    }
}