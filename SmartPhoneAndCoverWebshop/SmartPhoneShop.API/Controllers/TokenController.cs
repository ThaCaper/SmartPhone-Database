using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        private IUserRepository repository;
        private IAuthenticationHelper authenticationHelper;

        public TokenController(IUserRepository repos, IAuthenticationHelper authService)
        {
            repository = repos;
            authenticationHelper = authService;
        }


        [HttpPost]
        public IActionResult Login([FromBody]LoginInputModel model)
        {
            var owner = repository.GetAllUser().FirstOrDefault(u => u.Username == model.Username);

            // check if username exists
            if (owner == null)
                return Unauthorized();

            // check if password is correct
            if (!authenticationHelper.VerifyPasswordHash(model.Password, owner.PasswordHash, owner.PasswordSalt))
                return Unauthorized();

            // Authentication successful
            return Ok(new
            {
                username = owner.Username,
                token = authenticationHelper.GenerateToken(owner)
            });
        }
    }
}