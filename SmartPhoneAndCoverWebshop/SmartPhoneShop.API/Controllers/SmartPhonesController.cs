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
    public class SmartPhonesController : ControllerBase
    {
        private readonly ISmartPhoneService _smartPhoneService;

        public SmartPhonesController(ISmartPhoneService smartPhoneService)
        {
            _smartPhoneService = smartPhoneService;
        }

        // GET: api/SmartPhones
        [HttpGet]
        public ActionResult<IEnumerable<SmartPhone>> GetAllSmartPhones()
        {
            try
            {
                return Ok(_smartPhoneService.GetAllSmartPhone());
            }
            catch (Exception e)
            {
                return BadRequest("Did not find any SmartPhones");
            }
        }

        // GET: api/SmartPhones/5
        [HttpGet("{id}")]
        public ActionResult<SmartPhone> GetSmartPhoneById(int id)
        {
            if (id < 1) return BadRequest("Id must have greater than 0");
                return _smartPhoneService.GetSmartPhoneById(id);
        }

        // POST: api/SmartPhones
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<SmartPhone> Post([FromBody] SmartPhone phone)
        {
            try
            {
                return Ok(_smartPhoneService.CreateSmartPhone(phone));
            }
            catch (Exception e)
            {
                return BadRequest("Cannot create SmartPhones. Reason: " + e.Message);
            }
        }

        // PUT: api/SmartPhones/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<SmartPhone> Put(int id, [FromBody] SmartPhone phone)
        {
            if (id < 1 || id != phone.Id) 
                return BadRequest("Parameter Id and Order Id must be the same");

            return Ok(_smartPhoneService.UpdateSmartPhone(phone));
        }

        // DELETE: api/ApiWithActions/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<SmartPhone> Delete(int id)
        {
            var deletePhone = _smartPhoneService.DeleteSmartPhone(id);
            if (deletePhone == null) 
                return StatusCode(404, "Did not find any SmartPhone with that id" + id);

            return NoContent();
        }
    }
}