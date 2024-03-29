﻿using System.Collections.Generic;
using SmartPhoneShop.Entity;

namespace SmartPhoneShop.Core.DomainService
{
    public interface ISmartPhoneRepository
    {
        SmartPhone CreateSmartPhone(SmartPhone createdSmartPhone);

        List<SmartPhone> GetAllSmartPhones();

        SmartPhone GetSmartPhoneById(int id);

        SmartPhone UpdateSmartPhone(SmartPhone updatedSmartPhone);

        SmartPhone DeleteSmartPhone(int id);
    }
}