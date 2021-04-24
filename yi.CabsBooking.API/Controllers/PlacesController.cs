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
    public class PlacesController : ControllerBase
    {
        private readonly IPlacesService _placesService;

        public PlacesController(IPlacesService placesService)
        {
            _placesService = placesService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllPlaces()
        {
            var places = await _placesService.GetAllPlaces();
            return Ok(places);
        }

        [HttpPost]
        [Route("createPlace")]
        public async Task<IActionResult> CreatePlace(PlacesRegisterRequestModel model)
        {
            var place = await _placesService.CreatePlace(model);
            return Ok(place);
        }

        [HttpPut]
        [Route("updatePlace")]
        public async Task<IActionResult> UpdatePlace(UpdatePlacesRequestModel model)
        {
            var updatedPlace = await _placesService.UpdatePlace(model);
            return Ok(updatedPlace);
        }

        [HttpDelete]
        [Route("{id:int}", Name = "DeletePlace")]
        public async Task<IActionResult> DeletePlace(int id)
        {
            var place = await _placesService.DeletePlace(id);
            return Ok(place);
        }

    }
}
