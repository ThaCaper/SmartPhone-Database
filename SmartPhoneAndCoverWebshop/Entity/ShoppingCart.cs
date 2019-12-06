namespace SmartPhoneShop.Entity
{
    public class ShoppingCart
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int Qty { get; set; }
        public double PriceWhenBought { get; set; }
        public decimal Tax { get; set; }
        public int ProductId { get; set; }
        public SmartPhone SmartPhone { get; set; }
        public Cover Cover { get; set; }


    }
}