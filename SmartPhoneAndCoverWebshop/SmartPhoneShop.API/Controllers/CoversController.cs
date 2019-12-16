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
            try
            {
                return Ok(_coverService.GetAllCovers());
            }
            catch (Exception e)
            {
                return BadRequest("Did not find any Covers");
            }
        }

        // GET: api/Covers/5
        [HttpGet("{id}")]
        public ActionResult<Cover> GetCoverById(int id)
        {
            if (id < 1) 
                return BadRequest("Id must have greater than 0");

            return Ok(_coverService.GetCoverById(id));
        }

        // POST: api/Covers
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Cover> Post([FromBody] Cover cover)
        {
            try
            {
                return Ok(_coverService.CreateCover(cover));
            }
            catch (Exception e)
            {
                return BadRequest("Cannot create Covers. Reason: " + e.Message);
            }
        }

        // PUT: api/Covers/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] Cover cover)
        {
            if (id < 1 || id != cover.Id) 
                return BadRequest("Parameter Id and Order Id must be the same");

            return Ok(_coverService.UpdateCover(cover));
        }

        // DELETE: api/ApiWithActions/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            var cover = _coverService.DeleteCover(id);
            if (cover == null) 
                return StatusCode(404, "Did not fund any cover with that id");

            return NoContent();
        }
    }
}