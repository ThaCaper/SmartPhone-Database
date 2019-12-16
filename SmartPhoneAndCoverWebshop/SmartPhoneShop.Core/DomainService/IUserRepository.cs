using System.Collections.Generic;
using SmartPhoneShop.Entity;


namespace SmartPhoneShop.Core.DomainService
{
    public interface IUserRepository
    {
        User CreateUser(User createdUser);

        List<User> GetAllUser();

        User GetUserById(int id);

        User UpdateUser(User updatedUser);

        User DeleteUser(int id);
    }
}