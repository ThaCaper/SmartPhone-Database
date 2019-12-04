using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartPhoneShop.Core.DomainService;
using SmartPhoneShop.Entity;

namespace Infrastructure.SQL.Repositories
{
    public class UserRepository : IUserRepository
    {

        private DatabaseContext _context;
        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }
        public User CreateUser(User CreatedUser)
        {
            _context.Attach(CreatedUser).State = EntityState.Added;
            _context.SaveChanges();
            return CreatedUser;
        }

        public User DeleteUser(int id)
        {
            var UserRemove = _context.Remove(new User { Id = id }).Entity;
            _context.SaveChanges();
            return UserRemove;
        }

        public List<User> GetAllUser()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(c => c.Id == id);
        }

        public User UpdateUser(User UpdatedUser)
        {
            _context.Attach(UpdatedUser).State = EntityState.Modified;
            _context.Entry(UpdatedUser).Collection(u => u.ListOfOrders).IsModified = true;

            var orders = _context.Orders.Where(o => o.User.Id == UpdatedUser.Id
                                                    && !UpdatedUser.ListOfOrders.Exists(us => us.Id == o.Id));

            foreach (var order in orders)
            {
                order.User = null;
                _context.Entry(order).Reference(o => o.User)
                    .IsModified = true;
            }
            _context.Update(UpdatedUser);
            _context.SaveChanges();
            return UpdatedUser;
        }
    }
}