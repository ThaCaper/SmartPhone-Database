using System.Reflection.Metadata;

namespace SmartPhoneShop.Entity
{
    public class SmartPhone
    {
        public Product ProductType { get; set; }
        public string OS { get; set; }
        public string CPU_Type { get; set; }
        public string Camera { get; set; }
        public int Memory { get; set; }
        public double Screen { get; set; }
        public int Id { get; set; }
    }
}