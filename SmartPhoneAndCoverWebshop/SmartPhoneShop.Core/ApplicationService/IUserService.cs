using SmartPhoneShop.Entity;

namespace SmartPhoneShop.Core.ApplicationService
{
    public interface IUserService
    {
        User CreatUser(User user);

        User GetAllUser();
        User GetUserById(int id);

        User UpdateUser(User UpdateUser);

        User DeleteUser(int id);
    }
}