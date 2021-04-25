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
    public class BookingsHistoryController : ControllerBase
    {
        private readonly IBookingsHistoryService _bookingsHistory;

        public BookingsHistoryController(IBookingsHistoryService bookingsHistory)
        {
            _bookingsHistory = bookingsHistory;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllHistories()
        {
            var histories = await _bookingsHistory.GetAllBookingsHistories();
            return Ok(histories);
        }

        [HttpPost]
        [Route("createHistory")]
        public async Task<IActionResult> CreateHistory(BookingsHistoryRegisterRequestModel model)
        {
            var history = await _bookingsHistory.CreateHistory(model);
            return Ok(history);
        }

        [HttpPut]
        [Route("updateHistory")]
        public async Task<IActionResult> UpdateHistory(UpdateBookingsHistoryRequestModel model)
        {
            var updatedHistory = await _bookingsHistory.UpdateHistory(model);
            return Ok(updatedHistory);
        }

        [HttpDelete]
        [Route("{id:int}", Name = "DeleteHistory")]
        public async Task<IActionResult> DeleteHistory(int id)
        {
            var history = await _bookingsHistory.DeleteHistory(id);
            return Ok(history);
        }
  
    }
}
