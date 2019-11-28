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
    public class CoversController : ControllerBase
    {


        private readonly ICoverService _coverService;

        public CoversController(ICoverService coverService)
        {
            _coverService = coverService;
        }





        // GET: api/Covers
        [HttpGet]
        public List<Cover> Get()
        {
            return _coverService.GetAllCovers();
        }

        // GET: api/Covers/5
        [HttpGet("{id}", Name = "Get")]
        public Cover Get(int id)
        {
            return _coverService.GetCoverById(id);
        }

        // POST: api/Covers
        [HttpPost]
        public void Post([FromBody] Cover cover)
        {
            _coverService.CreateCover(cover);
        }

        // PUT: api/Covers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Cover cover)
        {
            _coverService.UpdateCover(cover);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _coverService.DeleteCover(id);
        }
    }
}
