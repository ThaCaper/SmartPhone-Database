using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartPhoneShop.Core.DomainService;
using SmartPhoneShop.Entity;

namespace Infrastructure.SQL.Repositories
{
    public class CoverRepository : ICoverRepository
    {
        private readonly DatabaseContext _context;

        public CoverRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Cover CreateCover(Cover createdCover)
        {
            _context.Attach(createdCover).State = EntityState.Added;
            _context.SaveChanges();
            return createdCover;
        }

        public Cover DeleteCover(int id)
        {
            var coverToRemove = _context.Remove(new Cover {Id = id}).Entity;
            _context.SaveChanges();
            return coverToRemove;
        }

        public List<Cover> GetAllCovers()
        {
            return _context.Covers.ToList();
        }

        public Cover GetCoverById(int id)
        {
            return _context.Covers.FirstOrDefault(c => c.Id == id);
        }

        public Cover UpdateCover(Cover updatedCover)
        {
            _context.Attach(updatedCover).State = EntityState.Modified;
            _context.Update(updatedCover);
            _context.SaveChanges();
            return updatedCover;
        }
    }
}