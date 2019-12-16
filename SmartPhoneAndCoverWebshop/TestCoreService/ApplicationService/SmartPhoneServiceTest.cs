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
    public class SmartPhoneServiceTest
    {
        [Fact]
        public void CreateSmartPhone()
        {
            var phone = new SmartPhone
            {
                Camera = "10 mega pixels",
                CpuType = "SnapDragon",
                Memory = 124,
                OS = "Android coffee",
                Name = "Xiao mi mix 2",
                Stock = 10,
                Price = 1234,
                Screen = 6.0
            };

            var smartPhoneRepo = new Mock<ISmartPhoneRepository>();
            smartPhoneRepo.Setup(x => x.CreateSmartPhone(phone)).Returns(phone);
            ISmartPhoneService service = new SmartPhoneService(smartPhoneRepo.Object);

            var result = service.CreateSmartPhone(phone);

            Assert.Equal(phone, result);
        }

        [Fact]
        public void CreateSmartPhoneWithMissingOSThrowsException()
        {
            var smartPhoneRepo = new Mock<ISmartPhoneRepository>();
            ISmartPhoneService service = new SmartPhoneService(smartPhoneRepo.Object);

            var phone = new SmartPhone
            {
                Camera = "10 mega pixels",
                CpuType = "SnapDragon",
                Memory = 124,
                Name = "Xiao mi mix 2",
                Screen = 6.0,
                Stock = 10,
                Price = 1234
            };
            Exception ex = Assert.Throws<InvalidDataException>(() => service.CreateSmartPhone(phone));
            Assert.Equal("Must have a OS", ex.Message);
        }


        [Fact]
        public void CreateSmartPhoneWithNoScreenThrowsException()
        {
            var smartPhoneRepo = new Mock<ISmartPhoneRepository>();
            ISmartPhoneService service = new SmartPhoneService(smartPhoneRepo.Object);

            var phone = new SmartPhone
            {
                Camera = "10 mega pixels",
                CpuType = "SnapDragon",
                Memory = 124,
                OS = "Android coffee",
                Name = "Xiao mi mix 2",
                Stock = 10,
                Price = 1234
            };

            Exception ex = Assert.Throws<InvalidDataException>(() => service.CreateSmartPhone(phone));
            Assert.Equal("Must have a screen size", ex.Message);
        }

        [Fact]
        public void DeleteSmartPhone()
        {
            var id = 1;
            var phone = new SmartPhone
            {
                Id = id,
                Camera = "10 mega pixels",
                CpuType = "Qualcomm SnapDragon",
                Memory = 124,
                OS = "Android coffee",
                Name = "Samsung Galaxy",
                Stock = 10,
                Price = 1234,
                Screen = 6.0
            };

            var smartPhoneRepo = new Mock<ISmartPhoneRepository>();
            smartPhoneRepo.Setup(x => x.DeleteSmartPhone(id)).Returns(phone);
            ISmartPhoneService service = new SmartPhoneService(smartPhoneRepo.Object);

            var result = service.DeleteSmartPhone(id);

            Assert.Equal(phone, result);
        }

        [Fact]
        public void DeleteSmartPhoneByGivingNonExistingIdThrowsException()
        {
            var id = 0;
            var smartPhoneRepo = new Mock<ISmartPhoneRepository>();
            smartPhoneRepo.Setup(x => x.DeleteSmartPhone(It.IsAny<int>())).Returns(default(SmartPhone));
            ISmartPhoneService service = new SmartPhoneService(smartPhoneRepo.Object);


            Exception ex = Assert.Throws<InvalidDataException>(() => service.DeleteSmartPhone(id));
            Assert.Equal("No SmartPhone with id: " + id + " exist", ex.Message);
        }

        [Fact]
        public void ReadAllSmartPhones()
        {
            var listOfSmartPhones = new List<SmartPhone>
            {
                new SmartPhone
                {
                    Camera = "10 mega pixels",
                    CpuType = "SnapDragon",
                    Memory = 124,
                    OS = "Android coffee",
                    Name = "Xiao mi mix 2",
                    Stock = 10,
                    Price = 1234,
                    Screen = 6.0
                },
                new SmartPhone
                {
                    Camera = "10 mega pixels",
                    CpuType = "Qualcomm SnapDragon",
                    Memory = 124,
                    OS = "Android coffee",
                    Name = "Samsung Galaxy",
                    Stock = 10,
                    Price = 1234,
                    Screen = 6.0
                }
            };

            var smartPhoneRepo = new Mock<ISmartPhoneRepository>();
            smartPhoneRepo.Setup(x => x.GetAllSmartPhones()).Returns(listOfSmartPhones);
            ISmartPhoneService service = new SmartPhoneService(smartPhoneRepo.Object);

            var result = service.GetAllSmartPhone();

            Assert.Equal(listOfSmartPhones, result);
        }

        [Fact]
        public void ReadSmartPhoneByGivingNonExistingIdThrowsException()
        {
            var id = 0;
            var smartPhoneRepo = new Mock<ISmartPhoneRepository>();
            smartPhoneRepo.Setup(x => x.GetSmartPhoneById(It.IsAny<int>())).Returns(default(SmartPhone));
            ISmartPhoneService service = new SmartPhoneService(smartPhoneRepo.Object);


            Exception ex = Assert.Throws<InvalidDataException>(() => service.GetSmartPhoneById(id));
            Assert.Equal("No SmartPhone with id: " + id + " exist", ex.Message);
        }

        [Fact]
        public void ReadSmartPhoneById()
        {
            var id = 1;
            var phone = new SmartPhone
            {
                Camera = "10 mega pixels",
                CpuType = "Qualcomm SnapDragon",
                Memory = 124,
                OS = "Android coffee",
                Name = "Samsung Galaxy",
                Stock = 10,
                Price = 1234,
                Screen = 6.0
            };

            var smartPhoneRepo = new Mock<ISmartPhoneRepository>();
            smartPhoneRepo.Setup(x => x.GetSmartPhoneById(id)).Returns(phone);
            ISmartPhoneService service = new SmartPhoneService(smartPhoneRepo.Object);

            var result = service.GetSmartPhoneById(id);

            Assert.Equal(phone, result);
        }

        [Fact]
        public void UpdateSmartPhone()
        {
            var phone = new SmartPhone
            {
                Camera = "10 mega pixels",
                CpuType = "Qualcomm SnapDragon",
                Memory = 124,
                OS = "Android coffee",
                Name = "Samsung Galaxy",
                Stock = 10,
                Price = 1234,
                Screen = 6.0
            };
            var updatedSmartPhone = new SmartPhone
            {
                Camera = "10 mega pixels",
                CpuType = "Qualcomm SnapDragon",
                Memory = 124,
                OS = "Android coffee",
                Name = "Samsung Galaxy",
                Stock = 10,
                Price = 1234,
                Screen = 5.0
            };

            phone = updatedSmartPhone;

            var smartPhoneRepo = new Mock<ISmartPhoneRepository>();
            smartPhoneRepo.Setup(x => x.UpdateSmartPhone(phone)).Returns(phone);
            ISmartPhoneService service = new SmartPhoneService(smartPhoneRepo.Object);

            var result = service.UpdateSmartPhone(phone);

            Assert.Equal(phone, result);
        }

        [Fact]
        public void UpdateSmartPhoneWithNewEmptyCpuThrowsException()
        {
            var smartPhoneRepo = new Mock<ISmartPhoneRepository>();
            ISmartPhoneService service = new SmartPhoneService(smartPhoneRepo.Object);

            var phone = new SmartPhone
            {
                Camera = "10 mega pixels",
                CpuType = "Qualcomm SnapDragon",
                Memory = 124,
                OS = "Android coffee",
                Name = "Samsung Galaxy",
                Stock = 10,
                Price = 1234,
                Screen = 6.0
            };
            var updatedSmartPhone = new SmartPhone
            {
                Camera = "10 mega pixels",
                CpuType = "",
                Memory = 124,
                OS = "Android Coffee",
                Name = "Samsung Galaxy",
                Stock = 10,
                Price = 1234,
                Screen = 5.0
            };

            phone = updatedSmartPhone;
            Exception ex = Assert.Throws<InvalidDataException>(() => service.UpdateSmartPhone(phone));
            Assert.Equal("Must have a CPU", ex.Message);
        }

        [Fact]
        public void UpdateWithSmartPhoneNewNoPriceThrowsException()
        {
            var smartPhoneRepo = new Mock<ISmartPhoneRepository>();
            ISmartPhoneService service = new SmartPhoneService(smartPhoneRepo.Object);

            var phone = new SmartPhone
            {
                Camera = "10 mega pixels",
                CpuType = "Qualcomm SnapDragon",
                Memory = 124,
                OS = "Android coffee",
                Name = "Samsung Galaxy",
                Stock = 10,
                Price = 1234,
                Screen = 6.0
            };
            var updatedSmartPhone = new SmartPhone
            {
                Camera = "10 mega pixels",
                CpuType = "Qualcomm SnapDragon",
                Memory = 124,
                OS = "Android Coffee",
                Name = "Samsung Galaxy",
                Stock = 10,
                Screen = 5.0
            };

            phone = updatedSmartPhone;

            Exception ex = Assert.Throws<InvalidDataException>(() => service.UpdateSmartPhone(phone));
            Assert.Equal("Must have a price", ex.Message);
        }
    }
}