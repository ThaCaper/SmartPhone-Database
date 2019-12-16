using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartPhoneShop.Core.DomainService;
using SmartPhoneShop.Entity;

namespace Infrastructure.SQL.Repositories
{
    public class SmartPhoneRepository : ISmartPhoneRepository
    {
        private readonly DatabaseContext _context;

        public SmartPhoneRepository(DatabaseContext context)
        {
            _context = context;
        }

        public SmartPhone CreateSmartPhone(SmartPhone createdSmartPhone)
        {
            _context.Attach(createdSmartPhone).State = EntityState.Added;
            _context.SaveChanges();
            return createdSmartPhone;
        }

        public List<SmartPhone> GetAllSmartPhones()
        {
            return _context.SmartPhones.ToList();
        }

        public SmartPhone GetSmartPhoneById(int id)
        {
            return _context.SmartPhones.FirstOrDefault(c => c.Id == id);
        }

        public SmartPhone UpdateSmartPhone(SmartPhone updatedSmartPhone)
        {
            _context.Attach(updatedSmartPhone).State = EntityState.Modified;
            _context.Update(updatedSmartPhone);
            _context.SaveChanges();
            return updatedSmartPhone;
        }

        public SmartPhone DeleteSmartPhone(int id)
        {
            var smartPhoneToRemove = _context.Remove(new SmartPhone {Id = id}).Entity;
            _context.SaveChanges();
            return smartPhoneToRemove;
        }
    }
}