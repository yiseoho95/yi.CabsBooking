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
    public class BookingsController : ControllerBase
    {
        private readonly IBookingsService _bookingsService;

        public BookingsController(IBookingsService bookingsService)
        {
            _bookingsService = bookingsService;
        }


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingsService.GetAllBookings();
            return Ok(bookings);
        }

        [HttpPost]
        [Route("createBookings")]
        public async Task<IActionResult> CreateBookings(BookingsRegisterRequestModel model)
        {
            var booking = await _bookingsService.CreateBookings(model);
            return Ok(booking);
        }

        [HttpPut]
        [Route("updateBooking")]
        public async Task<IActionResult> UpdateBooking(UpdateBookingsRequestModel model)
        {
            var updatedBookings = await _bookingsService.UpdateBookings(model);
            return Ok(updatedBookings);
        }

        [HttpDelete]
        [Route("{id:int}", Name = "DeleteBooking")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _bookingsService.DeleteBookings(id);
            return Ok(booking);
        }
    }
}
