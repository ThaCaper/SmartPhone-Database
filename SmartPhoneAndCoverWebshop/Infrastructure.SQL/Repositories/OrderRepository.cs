using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartPhoneShop.Core.DomainService;
using SmartPhoneShop.Entity;

namespace Infrastructure.SQL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DatabaseContext _ctx;

        public OrderRepository(DatabaseContext context)
        {
            _ctx = context;
        }

        public Order CreateOrder(Order createdOrder)
        {
            _ctx.Attach(createdOrder).State = EntityState.Added;
            _ctx.SaveChanges();
            return createdOrder;
        }

        public Order DeleteOrder(int id)
        {
            var removed = _ctx.Remove(new Order {Id = id}).Entity;
            _ctx.SaveChanges();
            return removed;
        }

        public List<Order> GetAllOrder()
        {
            return _ctx.Orders.Include(o => o.User)
                .Include(o => o.OrderLines)
                .ThenInclude(ol => ol.Product)
                .ToList();
        }

        public Order GetOrderById(int id)
        {
            return _ctx.Orders.Include(o => o.User)
                .Include(o => o.OrderLines)
                .ThenInclude(ol => ol.Product)
                .FirstOrDefault(o => o.Id == id);
        }

        public Order UpdateOrder(Order updatedOrder)
        {
            //Clone orderlines to new location in memory, so they are not overridden on Attach
            var newOrderLines = new List<OrderLine>(updatedOrder.OrderLines);
            //Attach order so basic properties are updated
            _ctx.Attach(updatedOrder).State = EntityState.Modified;
            //Remove all orderlines with updated order information
            _ctx.OrderLines.RemoveRange(
                _ctx.OrderLines.Where(ol => ol.OrderId == updatedOrder.Id));
            //Add all orderlines with updated order information
            foreach (var ol in newOrderLines)
            {
                _ctx.Entry(ol).State = EntityState.Added;
            }
            //Update customer relation
            _ctx.Entry(updatedOrder).Reference(o => o.User).IsModified = true;
            // Save it
            _ctx.SaveChanges();
            //Return it
            return updatedOrder;
        }
    }
}