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
  
            if (string.IsNullOrEmpty(user.FirstName))
            {
                throw new InvalidDataException("Must have a first name");
            }
            
            if (string.IsNullOrEmpty(user.LastName))
            {
                throw new InvalidDataException("Must have a last name");
            }

            if (string.IsNullOrEmpty(user.Email))
            {
                throw new InvalidDataException("Must have a email address");
            }

            if (string.IsNullOrEmpty(user.PhoneNumber))
            {
                throw new InvalidDataException("Must have a phone number");
            }

            if (string.IsNullOrEmpty(user.Username))
            {
                throw new InvalidDataException("Must have a username");
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                throw new InvalidDataException("For security a user must have a password");
            }

            if (string.IsNullOrEmpty(user.Street))
            {
                throw new InvalidDataException("Must have street");
            }

            if (string.IsNullOrEmpty(user.ZipCode))
            {
                throw new InvalidDataException("Must have a zipcode");
            }

            if (string.IsNullOrEmpty(user.Country))
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
            if (_userRepository.DeleteUser(id) == null)
            {
                throw new InvalidDataException("No User with id: " + id + " exist");
            }
            return _userRepository.DeleteUser(id);
        }

        public List<User> GetAllUser()
        {
            return _userRepository.GetAllUser();
        }

        public User GetUserById(int id)
        {
            if (_userRepository.GetUserById(id) == null)
            {
                throw new InvalidDataException("Can't find User with the id: " + id);
            }
            return _userRepository.GetUserById(id);
        }

        public User UpdateUser(PasswordUser updateUser)
        {
            if (string.IsNullOrEmpty(updateUser.FirstName))
            {
                throw new InvalidDataException("Must have a first name");
            }
            
            if (string.IsNullOrEmpty(updateUser.LastName))
            {
                throw new InvalidDataException("Must have a last name");
            }

            if (string.IsNullOrEmpty(updateUser.Email))
            {
                throw new InvalidDataException("Must have a email address");
            }

            if (string.IsNullOrEmpty(updateUser.PhoneNumber))
            {
                throw new InvalidDataException("Must have a phone number");
            }

            if (string.IsNullOrEmpty(updateUser.Username))
            {
                throw new InvalidDataException("Must have a username");
            }

            if (string.IsNullOrEmpty(updateUser.Password))
            {
                throw new InvalidDataException("For security a user must have a password");
            }

            if (string.IsNullOrEmpty(updateUser.Street))
            {
                throw new InvalidDataException("Must have street");
            }

            if (string.IsNullOrEmpty(updateUser.ZipCode))
            {
                throw new InvalidDataException("Must have a zipcode");
            }

            if (string.IsNullOrEmpty(updateUser.Country))
            {
                throw new InvalidDataException("Must have a country");
            }

            byte[] passwordHash, passwordSalt;
            _AuthenticationHelper.CreatePasswordHash( updateUser.Password, out passwordHash, out passwordSalt);
            updateUser.PasswordHash = passwordHash;
            updateUser.PasswordSalt = passwordSalt;

            return _userRepository.UpdateUser(updateUser);
        }

    }
}