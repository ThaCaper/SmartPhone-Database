using System.Collections.Generic;
using SmartPhoneShop.Entity;

namespace SmartPhoneShop.Core.ApplicationService
{
    public interface ISmartPhoneService
    {
        SmartPhone CreateSmartPhone(SmartPhone createdSmartPhone);

        List<SmartPhone> GetAllSmartPhone();

        SmartPhone GetSmartPhoneById(int id);

        SmartPhone UpdateSmartPhone(SmartPhone updatedSmartPhone);

        SmartPhone DeleteSmartPhone(int id);
    }
}