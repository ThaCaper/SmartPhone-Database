using System.Collections.Generic;
using SmartPhoneShop.Core.DomainService;
using SmartPhoneShop.Entity;

namespace SmartPhoneShop.Core.ApplicationService.impl
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;



        public UserService(IUserRepository userRepo)
        {
            _userRepository = userRepo;
        }



        public User CreateUser(User user)
        {
            return _userRepository.CreateUser(user);
        }

        public User DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }

        public List<User> GetAllUser()
        {
            return _userRepository.GetAllUser();
        }

        public User GetUserById(int id)
        {

            return _userRepository.GetUserById(id);

        }

        public User UpdateUser(User updateUser)
        {
            return _userRepository.UpdateUser(updateUser);
        }

    }
}