using System.Reflection.Metadata;

namespace SmartPhoneShop.Entity
{
    public class OrderLine
    {
        public int ProductId { get; set; }
        public SmartPhone SmartPhone { get; set; }
        public Cover Cover { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int Qty { get; set; }
        public double PriceWhenBought { get; set; }
    }
}