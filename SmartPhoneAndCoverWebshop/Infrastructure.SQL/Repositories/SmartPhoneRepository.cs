using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartPhoneShop.Core.DomainService;
using SmartPhoneShop.Entity;

namespace Infrastructure.SQL.Repositories
{
    public class SmartPhoneRepository : ISmartPhoneRepository
    {

        private DatabaseContext _context;
        public SmartPhoneRepository(DatabaseContext context)
        {
            _context = context;
        }

        public SmartPhone CreateSmartPhone(SmartPhone CreatedSP)
        {
            _context.Attach(CreatedSP).State = EntityState.Added;
            _context.SaveChanges();
            return CreatedSP;
        }

        public List<SmartPhone> GetAllSmartPhones()
        {
           return _context.SmartPhones.ToList();
        }

        public SmartPhone GetSmartPhoneById(int id)
        {
            return _context.SmartPhones.FirstOrDefault(c => c.Id == id);
        }

        public SmartPhone UpdateSmartPhone(SmartPhone UpdatedSP)
        {
            _context.Attach(UpdatedSP).State = EntityState.Modified;
            _context.Update(UpdatedSP);
            _context.SaveChanges();
            return UpdatedSP;
        }

        public SmartPhone DeleteSmartPhone(int id)
        {
            var coverRemove = _context.Remove(new Cover { Id = id }).Entity;
            _context.SaveChanges();
            return coverRemove;
        }
    }
}