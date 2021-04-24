using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities;

namespace ApplicationCore.Models.Response
{
    public class CabTypesResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookingsHistoryResponseModel> Bookings { get; set; }
       // public List<PlacesResponseModel> Places { get; set; }
    }
}
