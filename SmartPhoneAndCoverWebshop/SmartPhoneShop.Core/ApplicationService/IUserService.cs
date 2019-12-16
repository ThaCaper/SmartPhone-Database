using System.Collections.Generic;
using SmartPhoneShop.Entity;

namespace SmartPhoneShop.Core.ApplicationService
{
    public interface IUserService
    {
        User CreateUser(PasswordUser user);

        List<User> GetAllUser();

        User GetUserById(int id);

        User UpdateUser(PasswordUser updatedUser);

        User DeleteUser(int id);
    }
}