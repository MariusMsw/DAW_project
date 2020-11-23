using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Entities;
using ProiectDAW.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopController : ControllerBase
    {
        private readonly ILaptopService _laptopService;

        public LaptopController(ILaptopService LaptopService)
        {
            this._laptopService = LaptopService;
        }

        // GET: api/Laptop
        [HttpGet]
        public ActionResult<IEnumerable<Laptop>> GetLaptops()
        {
            IEnumerable<Laptop> Result = _laptopService.GetLaptops();
            if (Result == null)
            {
                return Ok(new List<Laptop>());
            }
            return Ok(Result);
        }

        // GET: api/Laptop/5
        [HttpGet("{LaptopId}")]
        public ActionResult<Laptop> GetLaptop(int LaptopId)
        {
            Laptop Result = _laptopService.GetLaptop(LaptopId);
            if (Result == null)
            {
                return NotFound(LaptopId);
            }
            return Ok(Result);
        }

        // PUT: api/Laptop/5
        [HttpPut("{LaptopId}")]
        public ActionResult<Laptop> UpdateLaptop(int LaptopId, Laptop Laptop)
        {
            Laptop Result = _laptopService.UpdateLaptop(LaptopId, Laptop);
            if (Result == null)
            {
                return NotFound(LaptopId);
            }
            return Ok(Result);
        }

        // POST: api/Laptop
        [HttpPost]
        public ActionResult<Laptop> CreateLaptop(Laptop Laptop)
        {
            Laptop Result = _laptopService.CreateLaptop(Laptop);
            return Ok(Laptop);
        }

        // DELETE: api/Laptop/5
        [HttpDelete("{LaptopId}")]
        public ActionResult<bool> DeleteLaptop(int LaptopId)
        {
            bool Result = _laptopService.DeleteLaptop(LaptopId);
            if (Result)
            {
                return Ok();
            }
            return NotFound(LaptopId);
        }
    }
}
