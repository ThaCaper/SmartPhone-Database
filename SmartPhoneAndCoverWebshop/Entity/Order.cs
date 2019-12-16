using System;
using System.Collections.Generic;

namespace SmartPhoneShop.Entity
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public User User { get; set; }

        public List<OrderLine> OrderLines { get; set; }
    }
}