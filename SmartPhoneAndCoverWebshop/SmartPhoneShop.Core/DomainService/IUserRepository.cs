using System.Collections.Generic;
using SmartPhoneShop.Entity;


namespace SmartPhoneShop.Core.DomainService
{
    public interface IUserRepository
    {
        User CreateUser(User CreatedUser);

        List<User> GetAllUser();

        User GetUserById(int id);

        User UpdateUser(User UpdatedUser);

        User DeleteUser(int id);
    }
}