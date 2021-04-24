using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;

namespace yi.CabsBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabTypesController : ControllerBase
    {
        private readonly ICabTypesService _cabTypesService;

        public CabTypesController(ICabTypesService cabTypesService)
        {
            _cabTypesService = cabTypesService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllCabTypes()
        {
            var cabs = await _cabTypesService.GetAllCabTypes();
            return Ok(cabs);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetCabHistory")]
        public async Task<IActionResult> GetCabById(int id)
        {
            var cabs = await _cabTypesService.GetCabTypesWithBookings(id);
            return Ok(cabs);
        }
    }
}
