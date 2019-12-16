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
    public class CoverServiceTest
    {
        [Fact]
        public void CreateCover()
        {
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
            var coverRepo = new Mock<ICoverRepository>();
            coverRepo.Setup(x => x.CreateCover(cover)).Returns(cover);
            ICoverService service = new CoverService(coverRepo.Object);


            var result = service.CreateCover(cover);

            Assert.Equal(cover, result);
        }

        [Fact]
        public void CreateCoverWithMissingNameThrowsException()
        {
            var coverRepo = new Mock<ICoverRepository>();
            ICoverService service = new CoverService(coverRepo.Object);

            var cover = new Cover
            {
                Color = "blue",
                Material = "plastic",
                TypeOfBrand = "Apple",
                TypeOfModel = "iPhone6",
                Stock = 10,
                Price = 1234
            };
            Exception ex = Assert.Throws<InvalidDataException>(() => service.CreateCover(cover));
            Assert.Equal("Must have a product name", ex.Message);
        }


        [Fact]
        public void CreateCoverWithNoPriceThrowsException()
        {
            var coverRepo = new Mock<ICoverRepository>();
            ICoverService service = new CoverService(coverRepo.Object);

            var cover = new Cover
            {
                Color = "blue",
                Material = "plastic",
                TypeOfBrand = "Apple",
                TypeOfModel = "iPhone6",
                Name = "Panser",
                Stock = 10
            };
            Exception ex = Assert.Throws<InvalidDataException>(() => service.CreateCover(cover));
            Assert.Equal("Must have a price", ex.Message);
        }

        [Fact]
        public void DeleteCover()
        {
            var id = 1;
            var cover = new Cover
            {
                Id = id,
                Material = "plastic",
                TypeOfBrand = "Samsung",
                TypeOfModel = "A10",
                Color = "blue",
                Name = "Samsung cover",
                Price = 100,
                Stock = 10
            };

            var coverRepo = new Mock<ICoverRepository>();
            coverRepo.Setup(x => x.DeleteCover(id)).Returns(cover);
            ICoverService service = new CoverService(coverRepo.Object);

            var result = service.DeleteCover(id);

            Assert.Equal(cover, result);
        }

        [Fact]
        public void DeleteCoverByGivingNonExistingIdThrowsException()
        {
            var id = 0;
            var coverRepo = new Mock<ICoverRepository>();
            coverRepo.Setup(x => x.DeleteCover(It.IsAny<int>())).Returns(default(Cover));
            ICoverService service = new CoverService(coverRepo.Object);


            Exception ex = Assert.Throws<InvalidDataException>(() => service.DeleteCover(id));
            Assert.Equal("No Cover with id: " + id + " exist", ex.Message);
        }

        [Fact]
        public void ReadAllCovers()
        {
            var listOfCovers = new List<Cover>
            {
                new Cover
                {
                    Material = "plastic",
                    TypeOfBrand = "Samsung",
                    TypeOfModel = "A10",
                    Color = "blue",
                    Name = "Samsung cover",
                    Price = 100,
                    Stock = 10
                },
                new Cover
                {
                    Material = "plastic",
                    TypeOfBrand = "Apple",
                    TypeOfModel = "cover",
                    Color = "red",
                    Name = "Apple cover",
                    Price = 150,
                    Stock = 10
                }
            };

            var coverRepo = new Mock<ICoverRepository>();
            coverRepo.Setup(x => x.GetAllCovers()).Returns(listOfCovers);
            ICoverService service = new CoverService(coverRepo.Object);

            var result = service.GetAllCovers();

            Assert.Equal(listOfCovers, result);
        }

        [Fact]
        public void ReadCoverByGivingNonExistingIdThrowsException()
        {
            var id = 0;
            var coverRepo = new Mock<ICoverRepository>();
            coverRepo.Setup(x => x.GetCoverById(It.IsAny<int>())).Returns(default(Cover));
            ICoverService service = new CoverService(coverRepo.Object);


            Exception ex = Assert.Throws<InvalidDataException>(() => service.DeleteCover(id));
            Assert.Equal("No Cover with id: " + id + " exist", ex.Message);
        }

        [Fact]
        public void ReadCoverById()
        {
            var id = 1;
            var cover = new Cover
            {
                Material = "plastic",
                TypeOfBrand = "Apple",
                TypeOfModel = "cover",
                Color = "red",
                Name = "Apple cover",
                Price = 150,
                Stock = 10
            };

            var coverRepo = new Mock<ICoverRepository>();
            coverRepo.Setup(x => x.GetCoverById(id)).Returns(cover);
            ICoverService service = new CoverService(coverRepo.Object);

            var result = service.GetCoverById(id);

            Assert.Equal(cover, result);
        }

        [Fact]
        public void UpdateCover()
        {
            var cover = new Cover
            {
                Material = "plastic",
                TypeOfBrand = "Samsung",
                TypeOfModel = "A10",
                Color = "blue",
                Name = "Samsung cover",
                Price = 100,
                Stock = 10
            };
            var updatedCover = new Cover
            {
                Material = "Plastic",
                TypeOfBrand = "Apple",
                TypeOfModel = "A10",
                Color = "Red",
                Name = "Apple cover",
                Price = 100,
                Stock = 10
            };

            cover = updatedCover;

            var coverRepo = new Mock<ICoverRepository>();
            coverRepo.Setup(x => x.UpdateCover(cover)).Returns(cover);
            ICoverService service = new CoverService(coverRepo.Object);

            var result = service.UpdateCover(cover);

            Assert.Equal(cover, result);
        }

        [Fact]
        public void UpdateCoverWithNewEmptyNameThrowsException()
        {
            var coverRepo = new Mock<ICoverRepository>();
            ICoverService service = new CoverService(coverRepo.Object);

            var cover = new Cover
            {
                Material = "plastic",
                TypeOfBrand = "Samsung",
                TypeOfModel = "A10",
                Color = "blue",
                Name = "Samsung cover",
                Price = 100,
                Stock = 10
            };
            var updatedCover = new Cover
            {
                Material = "Plastic",
                TypeOfBrand = "Apple",
                TypeOfModel = "A10",
                Color = "Red",
                Name = "",
                Price = 100,
                Stock = 10
            };

            cover = updatedCover;
            Exception ex = Assert.Throws<InvalidDataException>(() => service.UpdateCover(cover));
            Assert.Equal("Must have a name", ex.Message);
        }

        [Fact]
        public void UpdateWithCoverNewEmptyPriceThrowsException()
        {
            var coverRepo = new Mock<ICoverRepository>();
            ICoverService service = new CoverService(coverRepo.Object);

            var cover = new Cover
            {
                Material = "plastic",
                TypeOfBrand = "Samsung",
                TypeOfModel = "A10",
                Color = "blue",
                Name = "Samsung cover",
                Price = 100,
                Stock = 10
            };
            var updatedCover = new Cover
            {
                Material = "Plastic",
                TypeOfBrand = "Apple",
                TypeOfModel = "A10",
                Color = "Red",
                Name = "Apple Cover",
                Stock = 10
            };

            cover = updatedCover;
            Exception ex = Assert.Throws<InvalidDataException>(() => service.UpdateCover(cover));
            Assert.Equal("Must have a price", ex.Message);
        }

    }
}