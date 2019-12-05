using System.Collections.Generic;
using System.IO;
using SmartPhoneShop.Core.DomainService;
using SmartPhoneShop.Entity;

namespace SmartPhoneShop.Core.ApplicationService.impl
{

    public class SmartPhoneService : ISmartPhoneService
    {

        private readonly ISmartPhoneRepository _smartPhoneRepository;


        public SmartPhoneService(ISmartPhoneRepository smartRepo)
        {
            _smartPhoneRepository = smartRepo;
        }

        public SmartPhone CreateSmartPhone(SmartPhone CreatedSmartPhone)
        {
            if (CreatedSmartPhone.Name == null)
            {
                throw new InvalidDataException("Must have a product name");
            }

            if (CreatedSmartPhone.Price.Equals(null))
            {
                throw new InvalidDataException("Must have a price");
            }

            if (CreatedSmartPhone.Camera == null)
            {
                throw new InvalidDataException("Phones always have a camera");
            }

            if (CreatedSmartPhone.CpuType == null)
            {
                throw new InvalidDataException("Must have a CPU");
            }

            if (CreatedSmartPhone.Memory.Equals(null) || CreatedSmartPhone.Memory <= 0)
            {
                throw new InvalidDataException("Must have a certain amount of memory");
            }

            if (CreatedSmartPhone.OS == null)
            {
                throw new InvalidDataException("Must have a OS");
            }

            if(CreatedSmartPhone.Screen.Equals(null) || CreatedSmartPhone.Screen <= 0)
            {
                throw new InvalidDataException("Must have a screen size");
            }
            return _smartPhoneRepository.CreateSmartPhone(CreatedSmartPhone);
        }

        public SmartPhone DeleteSmartPhone(int id)
        {
            var phone = _smartPhoneRepository.DeleteSmartPhone(id);
            return phone;
        }

        public List<SmartPhone> GetAllSmartPhone()
        {
           return _smartPhoneRepository.GetAllSmartPhones();
        }

        public SmartPhone GetSmartPhoneById(int id)
        {
            return _smartPhoneRepository.GetSmartPhoneById(id);
        }

        public SmartPhone UpdateSmartPhone(SmartPhone UpdateSmartPhone)
        {
            return _smartPhoneRepository.UpdateSmartPhone(UpdateSmartPhone);

        }

    }
}
