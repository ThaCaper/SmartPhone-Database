using System.Collections.Generic;
using System.IO;
using SmartPhoneShop.Core.DomainService;
using SmartPhoneShop.Entity;

namespace SmartPhoneShop.Core.ApplicationService.impl
{
    public class UserService : IUserService
    {
        private readonly IAuthenticationHelper _authenticationHelper;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepo, IAuthenticationHelper authenticationHelper)
        {
            _userRepository = userRepo;

            _authenticationHelper = authenticationHelper;
        }

        public User CreateUser(PasswordUser user)
        {
            if (string.IsNullOrEmpty(user.FirstName)) 
                throw new InvalidDataException("Must have a first name");

            if (string.IsNullOrEmpty(user.LastName)) 
                throw new InvalidDataException("Must have a last name");

            if (string.IsNullOrEmpty(user.Email)) 
                throw new InvalidDataException("Must have a email address");

            if (string.IsNullOrEmpty(user.PhoneNumber)) 
                throw new InvalidDataException("Must have a phone number");

            if (string.IsNullOrEmpty(user.Username)) 
                throw new InvalidDataException("Must have a username");

            if (string.IsNullOrEmpty(user.Password))
                throw new InvalidDataException("For security a user must have a password");

            if (string.IsNullOrEmpty(user.Street)) 
                throw new InvalidDataException("Must have street");

            if (string.IsNullOrEmpty(user.ZipCode)) 
                throw new InvalidDataException("Must have a zipcode");

            if (string.IsNullOrEmpty(user.Country)) 
                throw new InvalidDataException("Must have a country");

            byte[] passwordHash, passwordSalt;
            _authenticationHelper.CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return _userRepository.CreateUser(user);
        }

        public User DeleteUser(int id)
        {
            if (_userRepository.DeleteUser(id) == null)
                throw new InvalidDataException("No User with id: " + id + " exist");

            return _userRepository.DeleteUser(id);
        }

        public List<User> GetAllUser()
        {
            return _userRepository.GetAllUser();
        }

        public User GetUserById(int id)
        {
            if (_userRepository.GetUserById(id) == null)
                throw new InvalidDataException("Can't find User with the id: " + id);

            return _userRepository.GetUserById(id);
        }

        public User UpdateUser(PasswordUser updatedUser)
        {
            if (string.IsNullOrEmpty(updatedUser.FirstName)) 
                throw new InvalidDataException("Must have a first name");

            if (string.IsNullOrEmpty(updatedUser.LastName)) 
                throw new InvalidDataException("Must have a last name");

            if (string.IsNullOrEmpty(updatedUser.Email)) 
                throw new InvalidDataException("Must have a email address");

            if (string.IsNullOrEmpty(updatedUser.PhoneNumber))
                throw new InvalidDataException("Must have a phone number");

            if (string.IsNullOrEmpty(updatedUser.Username)) 
                throw new InvalidDataException("Must have a username");

            if (string.IsNullOrEmpty(updatedUser.Password))
                throw new InvalidDataException("For security a user must have a password");

            if (string.IsNullOrEmpty(updatedUser.Street)) 
                throw new InvalidDataException("Must have street");

            if (string.IsNullOrEmpty(updatedUser.ZipCode)) 
                throw new InvalidDataException("Must have a zipcode");

            if (string.IsNullOrEmpty(updatedUser.Country)) 
                throw new InvalidDataException("Must have a country");

            byte[] passwordHash, passwordSalt;
            _authenticationHelper.CreatePasswordHash(updatedUser.Password, out passwordHash, out passwordSalt);
            updatedUser.PasswordHash = passwordHash;
            updatedUser.PasswordSalt = passwordSalt;

            return _userRepository.UpdateUser(updatedUser);
        }
    }
}