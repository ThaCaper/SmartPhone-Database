namespace SmartPhoneShop.Core.DomainService
{
    public interface IDbInitializer
    {
        void Initialize(DatabaseContext context);
    }
}