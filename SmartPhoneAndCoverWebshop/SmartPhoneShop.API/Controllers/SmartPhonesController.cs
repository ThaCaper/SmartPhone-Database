using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public ActionResult<IEnumerable<SmartPhone>> GetAllSmartphones()
        {
            return _smartPhoneService.GetAllSmartPhone();
        }

        // GET: api/SmartPhones/5
        [HttpGet("{id}")]
        public ActionResult<SmartPhone> GetSmartphoneById(int id)
        {
            return _smartPhoneService.GetSmartPhoneById(id);
        }

        // POST: api/SmartPhones
        [HttpPost]
        public ActionResult<SmartPhone> Post([FromBody] SmartPhone phone)
        {
            return _smartPhoneService.CreateSmartPhone(phone);
        }

        // PUT: api/SmartPhones/5
        [HttpPut("{id}")]
        public ActionResult<SmartPhone> Put(int id, [FromBody] SmartPhone phone)
        {

            try
            {
                return Ok(_smartPhoneService.UpdateSmartPhone(phone));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<SmartPhone> Delete(int id)
        {

            var deletephone =_smartPhoneService.DeleteSmartPhone(id);
            if (deletephone == null)
            {
                return StatusCode(404, "did not find any smartphone with that id"+ id);
            }

            return NoContent();
        }
    }
}
