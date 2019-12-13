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
            if (string.IsNullOrEmpty(CreatedSmartPhone.Name))
            {
                throw new InvalidDataException("Must have a product name");
            }

            if (CreatedSmartPhone.Price <= 0)
            {
                throw new InvalidDataException("Must have a price");
            }

            if (string.IsNullOrEmpty(CreatedSmartPhone.Camera))
            {
                throw new InvalidDataException("Phones always have a camera");
            }

            if (string.IsNullOrEmpty(CreatedSmartPhone.CpuType))
            {
                throw new InvalidDataException("Must have a CPU");
            }

            if (CreatedSmartPhone.Memory <= 0)
            {
                throw new InvalidDataException("Must have a certain amount of memory");
            }

            if (string.IsNullOrEmpty(CreatedSmartPhone.OS))
            {
                throw new InvalidDataException("Must have a OS");
            }

            if(CreatedSmartPhone.Screen <= 0)
            {
                throw new InvalidDataException("Must have a screen size");
            }
            return _smartPhoneRepository.CreateSmartPhone(CreatedSmartPhone);
        }

        public SmartPhone DeleteSmartPhone(int id)
        {
            if (_smartPhoneRepository.DeleteSmartPhone(id) == null)
            {
                throw new InvalidDataException("No SmartPhone with id: " + id + " exist");
            }
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
            if (string.IsNullOrEmpty(UpdateSmartPhone.Name))
            {
                throw new InvalidDataException("Must have a product name");
            }

            if (UpdateSmartPhone.Price <= 0)
            {
                throw new InvalidDataException("Must have a price");
            }

            if (string.IsNullOrEmpty(UpdateSmartPhone.Camera))
            {
                throw new InvalidDataException("Phones always have a camera");
            }

            if (string.IsNullOrEmpty(UpdateSmartPhone.CpuType))
            {
                throw new InvalidDataException("Must have a CPU");
            }

            if (UpdateSmartPhone.Memory <= 0)
            {
                throw new InvalidDataException("Must have a certain amount of memory");
            }

            if (string.IsNullOrEmpty(UpdateSmartPhone.OS))
            {
                throw new InvalidDataException("Must have a OS");
            }

            if(UpdateSmartPhone.Screen <= 0)
            {
                throw new InvalidDataException("Must have a screen size");
            }
            return _smartPhoneRepository.UpdateSmartPhone(UpdateSmartPhone);

        }

    }
}
