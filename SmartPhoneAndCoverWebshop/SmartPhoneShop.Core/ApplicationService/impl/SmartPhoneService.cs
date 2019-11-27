using System.Collections.Generic;
using SmartPhoneShop.Core.DomainService;
using SmartPhoneShop.Entity;

namespace SmartPhoneShop.Core.ApplicationService.impl
{

    public class SmartPhoneService : ISmartPhoneService
    {

        private ISmartPhoneRepository _smartPhoneRepository;

        private DatabaseContext _context;
        public CoverRepository(DatabaseContext context)
        {
            _context = context;
        }

        public SmartPhone CreateSmartPhone(SmartPhone CreatedSmartPhone)
        {
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
            _context.Attach(UpdateSmartPhone).State = EntityState.Modified;
            _context.Update(UpdateSmartPhone);
            _context.SaveChanges();
            return UpdateSmartPhone;

        }

    }
}