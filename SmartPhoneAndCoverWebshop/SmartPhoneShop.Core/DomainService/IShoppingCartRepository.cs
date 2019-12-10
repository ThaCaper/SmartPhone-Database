using System.Collections.Generic;
using SmartPhoneShop.Entity;

namespace SmartPhoneShop.Core.DomainService
{
    public interface IShoppingCartRepository
    {
        void AddToShoppingCart(int id);

        void DisposeProduct();

        int GetUserId();

        List<Product> GetProducts();

        double TotalAmount();

        int Count();
    }
}