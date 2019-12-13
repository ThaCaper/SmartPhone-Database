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
    public class UserServiceTest
    {
        public UserServiceTest()
        {

        }

        public void Dispose()
        {

        }

        [Fact]
        public void CreateUserWithMissingFirstNameThrowsException()
        {
            var user = new PasswordUser()
            {
                FirstName = null,
                LastName = "Nielsen",
                Email = "bent@1234.dk",
                PhoneNumber = "12345678",
                Country = "Denmark",
                Street = "H.C.Andersen gade 12",
                ZipCode = "5000",
                Username = "bn24744",
                Password = "bent",
                IsAdmin = false
            };

            var userRepo = new Mock<IUserRepository>();
            var auth = new Mock<IAuthenticationHelper>();
            IUserService service = new UserService(userRepo.Object, auth.Object);

            Exception ex = Assert.Throws<InvalidDataException>(() => service.CreateUser(user));
            Assert.Equal("Must have a first name", ex.Message);
        }

        [Fact]
        public void CreateUserWithBlankFirstNameThrowsException()
        {
            var user = new PasswordUser()
            {
                FirstName = "",
                LastName = "Nielsen",
                Email = "bent@1234.dk",
                PhoneNumber = "12345678",
                Country = "Denmark",
                Street = "H.C.Andersen gade 12",
                ZipCode = "5000",
                Username = "bn24744",
                Password = "bent",
                IsAdmin = false
            };

            var userRepo = new Mock<IUserRepository>();
            var auth = new Mock<IAuthenticationHelper>();
            IUserService service = new UserService(userRepo.Object, auth.Object);

            Exception ex = Assert.Throws<InvalidDataException>(() => service.CreateUser(user));
            Assert.Equal("Must have a first name", ex.Message);
        }

        [Fact]
        public void CreateUserGivesIsAdminFalse()
        {
            var user = new PasswordUser()
            {
                FirstName = "Bent",
                LastName = "Nielsen",
                Email = "bent@1234.dk",
                PhoneNumber = "12345678",
                Country = "Denmark",
                Street = "H.C.Andersen gade 12",
                ZipCode = "5000",
                Username = "bn24744",
                Password = "bent",
            };

            Assert.False(user.IsAdmin);
        }

        [Fact]
        public void ReadAllUsers()
        {
            List<User> ListOfUsers = new List<User>()
            {
                new PasswordUser()
                {
                    FirstName = "Peter",
                    LastName = "Nielsen",
                    Email = "pb@1234.dk",
                    PhoneNumber = "12345678",
                    Country = "Denmark",
                    Street = "H.C.Andersen gade 12",
                    ZipCode = "5000",
                    Username = "bn24744",
                    Password = "peter",
                },
                new PasswordUser()
                {
                    FirstName = "Bent",
                    LastName = "Nielsen",
                    Email = "bent@1234.dk",
                    PhoneNumber = "12345678",
                    Country = "Denmark",
                    Street = "H.C.Andersen gade 12",
                    ZipCode = "5000",
                    Username = "bn24744",
                    Password = "bent",
                }
            };

            var userRepo = new Mock<IUserRepository>();
            userRepo.Setup(x => x.GetAllUser()).Returns(ListOfUsers);
            var auth = new Mock<IAuthenticationHelper>();
            IUserService service = new UserService(userRepo.Object, auth.Object);

            var result = service.GetAllUser();

            Assert.Equal(ListOfUsers, result);
        }

        [Fact]
        public void ReadUserByGivingNonExistingIdThrowsException()
        {
            int id = 0;
            var userRepo = new Mock<IUserRepository>();
            userRepo.Setup(x => x.GetUserById(It.IsAny<int>())).Returns(default(User));
            var auth = new Mock<IAuthenticationHelper>();
            IUserService service = new UserService(userRepo.Object, auth.Object);


            Exception ex = Assert.Throws<InvalidDataException>(() => service.GetUserById(id));
            Assert.Equal("Can't find User with the id: " + id, ex.Message);
        }

        [Fact]
        public void ReadUSerById()
        {
            int id = 1;
            var user = new PasswordUser()
            {
                Id = id,
                FirstName = "Bent",
                LastName = "Nielsen",
                Email = "bent@1234.dk",
                PhoneNumber = "12345678",
                Country = "Denmark",
                Street = "H.C.Andersen gade 12",
                ZipCode = "5000",
                Username = "bn24744",
                Password = "bent",
            };

            var userRepo = new Mock<IUserRepository>();
            userRepo.Setup(x => x.GetUserById(id)).Returns(user);
            var auth = new Mock<IAuthenticationHelper>();
            IUserService service = new UserService(userRepo.Object, auth.Object);

            var result = service.GetUserById(id);

            Assert.Equal(user, result);
        }

        [Fact]
        public void UpdateUser()
        {
            var user1 = new PasswordUser()
            {
                FirstName = "Bent",
                LastName = "Nielsen",
                Email = "bent@1234.dk",
                PhoneNumber = "12345678",
                Country = "Denmark",
                Street = "H.C.Andersen gade 12",
                ZipCode = "5000",
                Username = "bn24744",
                Password = "bent",
            };

            var updatedUser = new PasswordUser()
            {
                FirstName = "Peter",
                LastName = "Nielsen",
                Email = "bent@1234.dk",
                PhoneNumber = "12345678",
                Country = "Denmark",
                Street = "H.C.Andersen gade 12",
                ZipCode = "5000",
                Username = "bn24744",
                Password = "bent",
            };

            user1 = updatedUser;

            var userRepo = new Mock<IUserRepository>();
            userRepo.Setup(x => x.UpdateUser(user1)).Returns(user1);
            var auth = new Mock<IAuthenticationHelper>();
            IUserService service = new UserService(userRepo.Object, auth.Object);

            var result = service.UpdateUser(user1);

            Assert.Equal(user1, result);
        }

        [Fact]
        public void UpdateUserWithEmptyFirstNameThrowsException()
        {
            var user1 = new PasswordUser()
            {
                FirstName = "Bent",
                LastName = "Nielsen",
                Email = "bent@1234.dk",
                PhoneNumber = "12345678",
                Country = "Denmark",
                Street = "H.C.Andersen gade 12",
                ZipCode = "5000",
                Username = "bn24744",
                Password = "bent",
            };

            var updatedUser = new PasswordUser()
            {
                LastName = "Nielsen",
                Email = "bent@1234.dk",
                PhoneNumber = "12345678",
                Country = "Denmark",
                Street = "H.C.Andersen gade 12",
                ZipCode = "5000",
                Username = "bn24744",
                Password = "bent",
            };

            user1 = updatedUser;

            var userRepo = new Mock<IUserRepository>();
            userRepo.Setup(x => x.UpdateUser(user1)).Returns(user1);
            var auth = new Mock<IAuthenticationHelper>();
            IUserService service = new UserService(userRepo.Object, auth.Object);

            Exception ex = Assert.Throws<InvalidDataException>(() => service.UpdateUser(user1));
            Assert.Equal("Must have a first name", ex.Message);
        }

        [Fact]
        public void DeleteUser()
        {
            int id = 1;
            var user1 = new PasswordUser()
            {
                Id = id,
                FirstName = "Bent",
                LastName = "Nielsen",
                Email = "bent@1234.dk",
                PhoneNumber = "12345678",
                Country = "Denmark",
                Street = "H.C.Andersen gade 12",
                ZipCode = "5000",
                Username = "bn24744",
                Password = "bent",
            };

            var userRepo = new Mock<IUserRepository>();
            userRepo.Setup(x => x.DeleteUser(id)).Returns(user1);
            var auth = new Mock<IAuthenticationHelper>();
            IUserService service = new UserService(userRepo.Object, auth.Object);

            var result = service.DeleteUser(id);
            
            Assert.Equal(user1, result);
        }

        [Fact]
        public void DeleteUserGivingNoneExistIdThrowsException()
        {
            int id = 0;
            var userRepo = new Mock<IUserRepository>();
            userRepo.Setup(x => x.DeleteUser(It.IsAny<int>())).Returns(default(PasswordUser));
            var auth = new Mock<IAuthenticationHelper>();
            IUserService service = new UserService(userRepo.Object, auth.Object);

            Exception ex = Assert.Throws<InvalidDataException>(() => service.DeleteUser(id));
            Assert.Equal("No User with id: " + id + " exist", ex.Message);
        }

    }
}