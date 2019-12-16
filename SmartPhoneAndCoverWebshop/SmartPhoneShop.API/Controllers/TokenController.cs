﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartPhoneShop.Core.ApplicationService;
using SmartPhoneShop.Core.DomainService;
using SmartPhoneShop.Entity;

namespace SmartPhoneShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticationHelper _authenticationHelper;
        private readonly IUserRepository _repository;

        public TokenController(IUserRepository repos, IAuthenticationHelper authService)
        {
            _repository = repos;
            _authenticationHelper = authService;
        }


        [HttpPost]
        public IActionResult Login([FromBody] LoginInputModel model)
        {
            var owner = _repository.GetAllUser().FirstOrDefault(u => u.Username == model.Username);

            // check if username exists
            if (owner == null)
                return Unauthorized();

            // check if password is correct
            if (!_authenticationHelper.VerifyPasswordHash(model.Password, owner.PasswordHash, owner.PasswordSalt))
                return Unauthorized();

            // Authentication successful
            return Ok(new
            {
                username = owner.Username,
                token = _authenticationHelper.GenerateToken(owner)
            });
        }
    }
}