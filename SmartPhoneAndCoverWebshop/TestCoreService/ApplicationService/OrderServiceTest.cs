using System;
using System.Collections.Generic;
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
        [Fact]
        public void CreateOrder()
        {
            var user = new PasswordUser
            {
                Id = 1,
                FirstName = "Bent",
                LastName = "Nielsen",
                Email = "bent@1234.dk",
                PhoneNumber = "12345678",
                Country = "Denmark",
                Street = "H.C.Andersen gade 12",
                ZipCode = "5000",
                Username = "bn24744",
                Password = "bent"
            };

            var cover = new Cover
            {
                Color = "blue",
                Material = "plastic",
                TypeOfBrand = "Apple",
                TypeOfModel = "iPhone6",
                Stock = 10,
                Price = 1234,
                Name = "PanserProof"
            };

            var ol = new OrderLine
            {
                Product = cover,
                ProductId = cover.Id,
                Qty = 2,
                PriceWhenBought = cover.Price
            };

            var order = new Order
            {
                User = user,
                DeliveryDate = DateTime.Now,
                OrderDate = DateTime.Now,
                OrderLines = new List<OrderLine>
                {
                    ol,
                    new OrderLine
                    {
                        Product = cover,
                        ProductId = cover.Id,
                        Qty = 2,
                        PriceWhenBought = cover.Price
                    }
                }
            };

            var userRepo = new Mock<IUserRepository>();
            userRepo.Setup(x => x.CreateUser(user)).Returns(user);

            var orderRepo = new Mock<IOrderRepository>();
            orderRepo.Setup(x => x.CreateOrder(order)).Returns(order);

            IOrderService service = new OrderService(orderRepo.Object, userRepo.Object);


            var result = service.CreateOrder(order);

            Assert.Equal(order, result);
        }

        [Fact]
        public void CreateOrderDeliveryDateMissingThrowsException()
        {
            var orderRepo = new Mock<IOrderRepository>();
            var userRepo = new Mock<IUserRepository>();
            IOrderService service = new OrderService(orderRepo.Object, userRepo.Object);

            var order = new Order
            {
                User = new User {Id = 1},
                OrderDate = DateTime.Now
            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.CreateOrder(order));
            Assert.Equal("Must have a Delivery Date", ex.Message);
        }

        [Fact]
        public void CreateOrderWithUserMissingThrowsException()
        {
            var orderRepo = new Mock<IOrderRepository>();
            var userRepo = new Mock<IUserRepository>();
            IOrderService service = new OrderService(orderRepo.Object, userRepo.Object);

            var order = new Order
            {
                DeliveryDate = DateTime.Now,
                OrderDate = DateTime.Now
            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.CreateOrder(order));
            Assert.Equal("Must have a User", ex.Message);
        }

        [Fact]
        public void DeleteOrder()
        {
            var id = 1;
            var user = new PasswordUser
            {
                Id = 1,
                FirstName = "Bent",
                LastName = "Nielsen",
                Email = "bent@1234.dk",
                PhoneNumber = "12345678",
                Country = "Denmark",
                Street = "H.C.Andersen gade 12",
                ZipCode = "5000",
                Username = "bn24744",
                Password = "bent"
            };

            var cover = new Cover
            {
                Color = "blue",
                Material = "plastic",
                TypeOfBrand = "Apple",
                TypeOfModel = "iPhone6",
                Stock = 10,
                Price = 1234,
                Name = "PanserProof"
            };

            var ol = new OrderLine
            {
                Product = cover,
                ProductId = cover.Id,
                Qty = 2,
                PriceWhenBought = cover.Price
            };

            var order = new Order
            {
                Id = id,
                User = user,
                DeliveryDate = DateTime.Now,
                OrderDate = DateTime.Now,
                OrderLines = new List<OrderLine>
                {
                    ol,
                    new OrderLine
                    {
                        Product = cover,
                        ProductId = cover.Id,
                        Qty = 2,
                        PriceWhenBought = cover.Price
                    }
                }
            };

            var userRepo = new Mock<IUserRepository>();
            userRepo.Setup(x => x.CreateUser(user)).Returns(user);

            var orderRepo = new Mock<IOrderRepository>();
            orderRepo.Setup(x => x.DeleteOrder(id)).Returns(order);

            IOrderService service = new OrderService(orderRepo.Object, userRepo.Object);

            var result = service.DeleteOrder(1);

            Assert.Equal(order, result);
        }

        [Fact]
        public void DeleteOrderWithNonExistingId()
        {
            var id = 0;
            var orderRepo = new Mock<IOrderRepository>();
            orderRepo.Setup(x => x.DeleteOrder(It.IsAny<int>())).Returns(default(Order));
            var userRepo = new Mock<IUserRepository>();
            IOrderService service = new OrderService(orderRepo.Object, userRepo.Object);

            Exception ex = Assert.Throws<InvalidDataException>(() => service.DeleteOrder(id));
            Assert.Equal("No Order with id: " + id + " exist", ex.Message);
        }

        [Fact]
        public void ReadAllOrders()
        {
            var id = 1;
            var user = new PasswordUser
            {
                Id = 1,
                FirstName = "Bent",
                LastName = "Nielsen",
                Email = "bent@1234.dk",
                PhoneNumber = "12345678",
                Country = "Denmark",
                Street = "H.C.Andersen gade 12",
                ZipCode = "5000",
                Username = "bn24744",
                Password = "bent"
            };

            var cover = new Cover
            {
                Color = "blue",
                Material = "plastic",
                TypeOfBrand = "Apple",
                TypeOfModel = "iPhone6",
                Stock = 10,
                Price = 1234,
                Name = "PanserProof"
            };

            var ol = new OrderLine
            {
                Product = cover,
                ProductId = cover.Id,
                Qty = 2,
                PriceWhenBought = cover.Price
            };

            var listOfOrders = new List<Order>
            {
                new Order
                {
                    Id = id,
                    User = user,
                    DeliveryDate = DateTime.Now,
                    OrderDate = DateTime.Now,
                    OrderLines = new List<OrderLine>
                    {
                        ol,
                        new OrderLine
                        {
                            Product = cover,
                            ProductId = cover.Id,
                            Qty = 2,
                            PriceWhenBought = cover.Price
                        }
                    }
                },
                new Order
                {
                    Id = id,
                    User = user,
                    DeliveryDate = DateTime.Now,
                    OrderDate = DateTime.Now,
                    OrderLines = new List<OrderLine>
                    {
                        ol,
                        new OrderLine
                        {
                            Product = cover,
                            ProductId = cover.Id,
                            Qty = 2,
                            PriceWhenBought = cover.Price
                        }
                    }
                }
            };

            var orderRepo = new Mock<IOrderRepository>();
            var userRepo = new Mock<IUserRepository>();
            IOrderService service = new OrderService(orderRepo.Object, userRepo.Object);

            orderRepo.Setup(x => x.GetAllOrder()).Returns(listOfOrders);

            var result = service.GetAllOrder();

            Assert.Equal(listOfOrders, result);
        }

        [Fact]
        public void ReadOrderById()
        {
            var id = 1;
            var user = new PasswordUser
            {
                Id = 1,
                FirstName = "Bent",
                LastName = "Nielsen",
                Email = "bent@1234.dk",
                PhoneNumber = "12345678",
                Country = "Denmark",
                Street = "H.C.Andersen gade 12",
                ZipCode = "5000",
                Username = "bn24744",
                Password = "bent"
            };

            var cover = new Cover
            {
                Color = "blue",
                Material = "plastic",
                TypeOfBrand = "Apple",
                TypeOfModel = "iPhone6",
                Stock = 10,
                Price = 1234,
                Name = "PanserProof"
            };

            var ol = new OrderLine
            {
                Product = cover,
                ProductId = cover.Id,
                Qty = 2,
                PriceWhenBought = cover.Price
            };

            var order = new Order
            {
                Id = id,
                User = user,
                DeliveryDate = DateTime.Now,
                OrderDate = DateTime.Now,
                OrderLines = new List<OrderLine>
                {
                    ol,
                    new OrderLine
                    {
                        Product = cover,
                        ProductId = cover.Id,
                        Qty = 2,
                        PriceWhenBought = cover.Price
                    }
                }
            };

            var orderRepo = new Mock<IOrderRepository>();
            orderRepo.Setup(x => x.GetOrderById(id)).Returns(order);
            var userRepo = new Mock<IUserRepository>();
            IOrderService service = new OrderService(orderRepo.Object, userRepo.Object);

            var result = service.GetOrderById(id);

            Assert.Equal(order, result);
        }

        [Fact]
        public void ReadOrderByNonExistingIdThrowsException()
        {
            var id = 0;
            var orderRepo = new Mock<IOrderRepository>();
            var userRepo = new Mock<IUserRepository>();
            orderRepo.Setup(x => x.GetOrderById(It.IsAny<int>())).Returns(default(Order));
            IOrderService service = new OrderService(orderRepo.Object, userRepo.Object);

            Exception ex = Assert.Throws<InvalidDataException>(() => service.GetOrderById(id));
            Assert.Equal("No Order with id: " + id + " exist", ex.Message);
        }

        [Fact]
        public void UpdateOrder()
        {
            var user = new PasswordUser
            {
                Id = 1,
                FirstName = "Bent",
                LastName = "Nielsen",
                Email = "bent@1234.dk",
                PhoneNumber = "12345678",
                Country = "Denmark",
                Street = "H.C.Andersen gade 12",
                ZipCode = "5000",
                Username = "bn24744",
                Password = "bent"
            };

            var cover = new Cover
            {
                Color = "blue",
                Material = "plastic",
                TypeOfBrand = "Apple",
                TypeOfModel = "iPhone6",
                Stock = 10,
                Price = 1234,
                Name = "PanserProof"
            };

            var ol = new OrderLine
            {
                Product = cover,
                ProductId = cover.Id,
                Qty = 2,
                PriceWhenBought = cover.Price
            };

            var order = new Order
            {
                User = user,
                DeliveryDate = DateTime.Now,
                OrderDate = DateTime.Now,
                OrderLines = new List<OrderLine>
                {
                    ol,
                    new OrderLine
                    {
                        Product = cover,
                        ProductId = cover.Id,
                        Qty = 2,
                        PriceWhenBought = cover.Price
                    }
                }
            };


            var userRepo = new Mock<IUserRepository>();
            userRepo.Setup(x => x.CreateUser(user)).Returns(user);

            var orderRepo = new Mock<IOrderRepository>();
            orderRepo.Setup(x => x.CreateOrder(order)).Returns(order);

            var updatedOrder = new Order
            {
                User = user,
                DeliveryDate = DateTime.Now,
                OrderDate = DateTime.Now,
                OrderLines = new List<OrderLine>
                {
                    ol,
                    new OrderLine
                    {
                        Product = cover,
                        ProductId = cover.Id,
                        Qty = 3,
                        PriceWhenBought = cover.Price
                    }
                }
            };
            order = updatedOrder;

            orderRepo.Setup(x => x.UpdateOrder(order)).Returns(order);

            IOrderService service = new OrderService(orderRepo.Object, userRepo.Object);

            var result = service.UpdateOrder(order);

            Assert.Equal(order, result);
        }

        [Fact]
        public void UpdateOrderRemoveDeliveryDateThrowsException()
        {
            var user = new PasswordUser
            {
                Id = 1,
                FirstName = "Bent",
                LastName = "Nielsen",
                Email = "bent@1234.dk",
                PhoneNumber = "12345678",
                Country = "Denmark",
                Street = "H.C.Andersen gade 12",
                ZipCode = "5000",
                Username = "bn24744",
                Password = "bent"
            };

            var cover = new Cover
            {
                Color = "blue",
                Material = "plastic",
                TypeOfBrand = "Apple",
                TypeOfModel = "iPhone6",
                Stock = 10,
                Price = 1234,
                Name = "PanserProof"
            };

            var ol = new OrderLine
            {
                Product = cover,
                ProductId = cover.Id,
                Qty = 2,
                PriceWhenBought = cover.Price
            };

            var order = new Order
            {
                User = user,
                DeliveryDate = DateTime.Now,
                OrderDate = DateTime.Now,
                OrderLines = new List<OrderLine>
                {
                    ol,
                    new OrderLine
                    {
                        Product = cover,
                        ProductId = cover.Id,
                        Qty = 2,
                        PriceWhenBought = cover.Price
                    }
                }
            };


            var userRepo = new Mock<IUserRepository>();
            userRepo.Setup(x => x.CreateUser(user)).Returns(user);

            var orderRepo = new Mock<IOrderRepository>();
            orderRepo.Setup(x => x.CreateOrder(order)).Returns(order);

            var updatedOrder = new Order
            {
                User = user,
                OrderDate = DateTime.Now,
                OrderLines = new List<OrderLine>
                {
                    ol,
                    new OrderLine
                    {
                        Product = cover,
                        ProductId = cover.Id,
                        Qty = 3,
                        PriceWhenBought = cover.Price
                    }
                }
            };
            order = updatedOrder;

            IOrderService service = new OrderService(orderRepo.Object, userRepo.Object);

            Exception ex = Assert.Throws<InvalidDataException>(() => service.UpdateOrder(order));
            Assert.Equal("Must have a Delivery Date", ex.Message);
        }
    }
}