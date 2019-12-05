using System.Collections.Generic;
using System.IO;
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
            if (user.Id <= 0)
            {
                throw new InvalidDataException("User not found");
            }

            if (user.FirstName == null)
            {
                throw new InvalidDataException("Must have a first name");
            }

            if (user.LastName == null)
            {
                throw new InvalidDataException("Must have a last name");
            }

            if (user.Email == null)
            {
                throw new InvalidDataException("Must have a email address");
            }

            if (user.PhoneNumber == null)
            {
                throw new InvalidDataException("Must have a phone number");
            }

            if (user.Username == null)
            {
                throw new InvalidDataException("Must have a username");
            }

            if (user.Street == null)
            {
                throw new InvalidDataException("Must have street");
            }

            if (user.ZipCode == null)
            {
                throw new InvalidDataException("Must have a zipcode");
            }

            if (user.Country == null)
            {
                throw new InvalidDataException("Must have a country");
            }
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