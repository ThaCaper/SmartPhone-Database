using System.Collections.Generic;
using SmartPhoneShop.Entity;

namespace SmartPhoneShop.Core.DomainService
{
    public interface ISmartPhoneRepository
    {
        SmartPhone CreateSmartPhone(SmartPhone CreatedSP);

        List<SmartPhone> GetAllSmartPhones();

        SmartPhone GetSmartPhoneById(int id);

        SmartPhone UpdateSmartPhone(SmartPhone UpdatedSP);

        SmartPhone DeleteSmartPhone(int id);
    }
}