using System.Collections.Generic;
using System.IO;
using Microsoft.IdentityModel.Tokens;
using SmartPhoneShop.Core.DomainService;
using SmartPhoneShop.Entity;

namespace SmartPhoneShop.Core.ApplicationService.impl
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IAuthenticationHelper _AuthenticationHelper;

        public UserService( IUserRepository userRepo , IAuthenticationHelper authenticationHelper)
        {
            _userRepository = userRepo;

            _AuthenticationHelper = authenticationHelper;
        }

        public User CreateUser(PasswordUser user)
        {
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

            byte[] passwordHash, passwordSalt;
            _AuthenticationHelper.CreatePasswordHash( user.Password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            
          
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