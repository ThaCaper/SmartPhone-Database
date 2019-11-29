using System.Collections.Generic;
using SmartPhoneShop.Core.ApplicationService;
using SmartPhoneShop.Core.DomainService;
using SmartPhoneShop.Entity;

namespace Infrastructure.SQL
{
    public class DBInitializer : IDBinitializer
    {

        private IAuthenticationHelper authenticationHelper;

        public DBInitializer(IAuthenticationHelper authelper)
        {
            authenticationHelper = authelper;
        }

        public void Initialize(DatabaseContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            List<SmartPhone> ListOfSmartphones = new List<SmartPhone>
            {
                new SmartPhone()
                {
                    Name = "iphone",
                    Price = 6500,
                    OS = "IOS",
                    CPU_Type = "A7",
                    Camera = "12mega px",
                    Memory = 64,
                    Screen = 5.5
                },



                new SmartPhone()
                {
                
                Name = "Samung",
                Price = 6500,
            
            OS = "Windows",
            CPU_Type = "q2",
            Camera = "12mega px",
            Memory = 124,
            Screen = 5.5
            }


            };
  


            var c1 = context.Covers.Add(new Cover()
            {
                Material = "plastic",
                TypeOfBrand = "Samsung",
                TypeOfModel = "A10",
              
                    Name = "Samsung cover",
                    Price = 100
               
            }).Entity;

            var c2 = context.Covers.Add(new Cover()
            {
                Material = "plastic",
                TypeOfBrand = "Apple",
                TypeOfModel = "cover",
               
                    Name = "Apple cover",
                    Price = 150
                
            }).Entity;






            string password = "1234";
            byte[] passwordHashJoe, passwordSaltJoe, passwordHashAnn, passwordSaltAnn;
            authenticationHelper.CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);
            authenticationHelper.CreatePasswordHash(password, out passwordHashAnn, out passwordSaltAnn);


            List<User> users = new List<User>
            {
                new User() {
                    FirstName = "Joe",
                    LastName = "johnsson",
                 
                        Street = "Ostestrasse",
                        Country = "Tyskland",
                        ZipCode = "0001",
                   
                    Email = "joe@hotmail.com",
                    PhoneNumber = "12345678",
                    Username = "UserJoe",
                    PasswordHash = passwordHashJoe,
                    PasswordSalt = passwordSaltJoe,
                    IsAdmin = false
                },
                new User() {
                    FirstName = "Ann",
                    LastName = "petersen",
                  
                        Street = "vestergade",
                        Country = "Danmark",
                        ZipCode = "5560",
                   
                    Email = "Ann@hotmail.com",
                    PhoneNumber = "87654321",
                    Username = "AdminAnn",
                    PasswordHash = passwordHashAnn,
                    PasswordSalt = passwordSaltAnn,
                    IsAdmin = true
                }
            };


            context.SmartPhones.AddRange(ListOfSmartphones);
            context.Covers.Add(c1);
            context.Covers.Add(c2);
            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
    }