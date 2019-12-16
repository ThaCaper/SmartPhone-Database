using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartPhoneShop.Core.DomainService;
using SmartPhoneShop.Entity;

namespace Infrastructure.SQL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public User CreateUser(User createdUser)
        {
            _context.Attach(createdUser).State = EntityState.Added;
            _context.SaveChanges();
            return createdUser;
        }

        public User DeleteUser(int id)
        {
            var userToRemove = _context.Remove(new User {Id = id}).Entity;
            _context.SaveChanges();
            return userToRemove;
        }

        public List<User> GetAllUser()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(c => c.Id == id);
        }

        public User UpdateUser(User updatedUser)
        {
            _context.Attach(updatedUser).State = EntityState.Modified;
            _context.Entry(updatedUser).Collection(u => u.ListOfOrders).IsModified = true;

            var orders = _context.Orders.Where(o => o.User.Id == updatedUser.Id
                                                    && !updatedUser.ListOfOrders.Exists(us => us.Id == o.Id));

            foreach (var order in orders)
            {
                order.User = null;
                _context.Entry(order).Reference(o => o.User)
                    .IsModified = true;
            }

            _context.Update(updatedUser);
            _context.SaveChanges();
            return updatedUser;
        }
    }
}