using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
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

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                return Ok(_userService.GetAllUser());
            }
            catch (Exception e)
            {
                return BadRequest("Cannot find any Users");
            }
        }

        // GET: api/Users/5
        [Authorize(Roles = "PowerUser, Administrator")]
        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            if (id < 0) return BadRequest("Id must have greater than 0");
            return _userService.GetUserById(id);
        }

        // POST: api/Users

        [HttpPost]
        public ActionResult<User> Post([FromBody] PasswordUser user)
        {
            try
            {
                return Ok(_userService.CreateUser(user));
            }
            catch (Exception e)
            {
                return BadRequest("Cannot create user. Reason: " + e.Message);
            }
        }

        // PUT: api/Users/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] PasswordUser user)
        {
            if (id < 1 || id != user.Id) 
                return BadRequest("Parameter Id and Order Id must be the same");

            return Ok(_userService.UpdateUser(user));
        }

        // DELETE: api/ApiWithActions/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            var userToBeDelete = _userService.DeleteUser(id);
            if (userToBeDelete == null) 
                return StatusCode(404, "did not find any user with that id" + id);
            
            return NoContent();
        }
    }
}