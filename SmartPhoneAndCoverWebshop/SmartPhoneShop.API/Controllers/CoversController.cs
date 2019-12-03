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
    public class CoversController : ControllerBase
    {
        private readonly ICoverService _coverService;

        public CoversController(ICoverService coverService)
        {
            _coverService = coverService;
        }

        // GET: api/Covers
        [HttpGet]
        public ActionResult<IEnumerable<Cover>> GetAllCovers()
        {
            return _coverService.GetAllCovers();
        }

        // GET: api/Covers/5
        [HttpGet("{id}")]
        public ActionResult<Cover> GetCoverById(int id)
        {
            return _coverService.GetCoverById(id);
        }

        // POST: api/Covers
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Cover> Post([FromBody] Cover cover)
        {
            return _coverService.CreateCover(cover);
        }

        // PUT: api/Covers/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] Cover cover)
        {
            try
            {
                return Ok(_coverService.UpdateCover(cover));
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
           var co = _coverService.DeleteCover(id);
           if (co == null)
           {
               return StatusCode(404, "did not fund any cover with that id");
           }

           return NoContent();
        }
    }
}
