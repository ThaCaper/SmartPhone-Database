using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartPhoneShop.Core.ApplicationService;
using SmartPhoneShop.Entity;

namespace SmartPhoneShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userservice)
        {
            _userService = userservice;
        }

        // GET: api/Users
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            return _userService.GetAllUser();
        }

        // GET: api/Users/5
        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            return _userService.GetUserById(id);
        }

        // POST: api/Users
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
          return  _userService.CreateUser(user);
        }

        // PUT: api/Users/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User user)
        {
            try
            {
                return Ok(_userService.UpdateUser(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            var userToBeDelete = _userService.DeleteUser(id);
           if (userToBeDelete == null)
           {
               return StatusCode(404, "did not find any user with that id"+ id);
           }
           return NoContent();
        }
    }
}
