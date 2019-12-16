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

        public SmartPhone CreateSmartPhone(SmartPhone createdSmartPhone)
        {
            if (string.IsNullOrEmpty(createdSmartPhone.Name))
                throw new InvalidDataException("Must have a product name");

            if (createdSmartPhone.Price <= 0) throw 
                new InvalidDataException("Must have a price");

            if (string.IsNullOrEmpty(createdSmartPhone.Camera))
                throw new InvalidDataException("Phones always have a camera");

            if (string.IsNullOrEmpty(createdSmartPhone.CpuType)) 
                throw new InvalidDataException("Must have a CPU");

            if (createdSmartPhone.Memory <= 0) 
                throw new InvalidDataException("Must have a certain amount of memory");

            if (string.IsNullOrEmpty(createdSmartPhone.OS)) 
                throw new InvalidDataException("Must have a OS");

            if (createdSmartPhone.Screen <= 0) 
                throw new InvalidDataException("Must have a screen size");
            
            return _smartPhoneRepository.CreateSmartPhone(createdSmartPhone);
        }

        public SmartPhone DeleteSmartPhone(int id)
        {
            if (_smartPhoneRepository.DeleteSmartPhone(id) == null)
                throw new InvalidDataException("No SmartPhone with id: " + id + " exist");
            
            var phone = _smartPhoneRepository.DeleteSmartPhone(id);
            return phone;
        }

        public List<SmartPhone> GetAllSmartPhone()
        {
            return _smartPhoneRepository.GetAllSmartPhones();
        }

        public SmartPhone GetSmartPhoneById(int id)
        {
            if (_smartPhoneRepository.GetSmartPhoneById(id) == null)
                throw new InvalidDataException("No SmartPhone with id: " + id + " exist");
            
            return _smartPhoneRepository.GetSmartPhoneById(id);
        }

        public SmartPhone UpdateSmartPhone(SmartPhone updatedSmartPhone)
        {
            if (string.IsNullOrEmpty(updatedSmartPhone.Name)) 
                throw new InvalidDataException("Must have a product name");

            if (updatedSmartPhone.Price <= 0) 
                throw new InvalidDataException("Must have a price");

            if (string.IsNullOrEmpty(updatedSmartPhone.Camera))
                throw new InvalidDataException("Phones always have a camera");

            if (string.IsNullOrEmpty(updatedSmartPhone.CpuType)) 
                throw new InvalidDataException("Must have a CPU");

            if (updatedSmartPhone.Memory <= 0) 
                throw new InvalidDataException("Must have a certain amount of memory");

            if (string.IsNullOrEmpty(updatedSmartPhone.OS)) 
                throw new InvalidDataException("Must have a OS");

            if (updatedSmartPhone.Screen <= 0)
                throw new InvalidDataException("Must have a screen size");
            
            return _smartPhoneRepository.UpdateSmartPhone(updatedSmartPhone);
        }
    }
}