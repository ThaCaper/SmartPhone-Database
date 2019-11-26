using System.Collections.Generic;
using SmartPhoneShop.Entity;

namespace SmartPhoneShop.Core.ApplicationService
{
    public interface ISmartPhoneService
    {
        SmartPhone CreateSmartPhone(SmartPhone CreatedSmartPhone);

        List<SmartPhone> GetAllSmartPhone();

        SmartPhone GetSmartPhoneById(int id);

        SmartPhone UpdateSmartPhone(SmartPhone UpdateSmartPhone);

        SmartPhone DeleteSmartPhone(int id);
    }
}