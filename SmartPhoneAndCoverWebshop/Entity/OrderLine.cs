

namespace SmartPhoneShop.Entity
{
    public class OrderLine
    {

        public Product Product { get; set; }

        public int ProductId { get; set; }
        
        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int Qty { get; set; }
        
        public double PriceWhenBought { get; set; }
    }
}