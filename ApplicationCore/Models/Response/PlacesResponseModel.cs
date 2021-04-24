using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models.Response
{
    public class PlacesResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookingsHistoryResponseModel> Bookings { get; set; }
    }
}
