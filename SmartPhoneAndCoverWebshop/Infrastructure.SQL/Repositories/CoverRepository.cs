using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartPhoneShop.Core.DomainService;
using SmartPhoneShop.Entity;

namespace Infrastructure.SQL.Repositories
{
    public class CoverRepository : ICoverRepository
    {
        private DatabaseContext _context;
        public CoverRepository(DatabaseContext context)
        {
            _context = context;
        }
        public Cover CreateCover(Cover CreatedCover)
        {
            _context.Attach(CreatedCover).State = EntityState.Added;
            _context.SaveChanges();
            return CreatedCover;
        }

        public Cover DeleteCover(int id)
        {
            var coverRemove = _context.Remove(new Cover { Id = id }).Entity;
            _context.SaveChanges();
            return coverRemove;
        }

        public List<Cover> GetAllCovers()
        {
            return _context.Covers.ToList();
        }

        public Cover GetCoverById(int id)
        {
            return _context.Covers.FirstOrDefault(c => c.Id == id);
            
        }

        public Cover UpdateCover(Cover UpdateCover)
        {
            _context.Attach(UpdateCover).State = EntityState.Modified;
            _context.Update(UpdateCover);
            _context.SaveChanges();
            return UpdateCover;
        }
    }
}