using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;
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

        [HttpPost]
        [Route("createCab")]
        public async Task<IActionResult> CreateCab(CabTypesRegisterRequestModel model)
        {
            var cab = await _cabTypesService.CreateCab(model);
            return Ok(cab);
        }

        [HttpPut]
        [Route("updateCab")]
        public async Task<IActionResult> UpdateCab(UpdateCabTypeRequestModel model)
        {
            var updatedCab = await _cabTypesService.UpdateCab(model);
            return Ok(updatedCab);
        }

        [HttpDelete]
        [Route("{id:int}", Name = "DeleteUser")]
        public async Task<IActionResult> DeleteCab(int id)
        {
            var cab = await _cabTypesService.DeleteCab(id);
            return Ok(cab);
        }
    }
}
