using System;
using System.IO;
using Moq;
using SmartPhoneShop.Core.ApplicationService;
using SmartPhoneShop.Core.ApplicationService.impl;
using SmartPhoneShop.Core.DomainService;
using SmartPhoneShop.Entity;
using Xunit;

namespace TestCoreService.ApplicationService
{
    public class OrderServiceTest
    {
        public OrderServiceTest()
        {
            var orderRepo = new Mock<IOrderRepository>();
            var userRepo = new Mock<IUserRepository>();
            IOrderService service = new OrderService(orderRepo.Object, userRepo.Object);
        }

        public void Dispose()
        {

        }

        [Fact]
        public void CreateOrderWithUserMissingThrowsException()
        {
              
        }
        
        [Fact]
        public void CreateOrderDeliveryDateMissingThrowsException()
        {

        }
        
        [Fact]
        public void CreateOrderShouldCallOrderRepoCreateOrderOnce()
        {

        }

    }
}