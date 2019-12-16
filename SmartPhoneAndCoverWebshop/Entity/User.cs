using System.Collections.Generic;


namespace SmartPhoneShop.Entity
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public bool IsAdmin { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Street { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }

        public List<Order> ListOfOrders { get; set; }
    }
}