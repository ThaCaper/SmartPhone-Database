using System.Reflection.Metadata;

namespace SmartPhoneShop.Entity
{
    public class SmartPhone : Product
    {
      
        public string OS { get; set; }
        public string CpuType { get; set; }
        public string Camera { get; set; }
        public int Memory { get; set; }
        public double Screen { get; set; }
    }
}