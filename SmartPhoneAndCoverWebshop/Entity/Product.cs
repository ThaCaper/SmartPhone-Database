using System.Collections.Generic;

namespace SmartPhoneShop.Entity
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public List<OrderLine> OrderLines { get; set; }
}
}