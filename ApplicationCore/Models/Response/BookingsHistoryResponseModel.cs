using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities;

namespace ApplicationCore.Models.Response
{
    public class BookingsHistoryResponseModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int FromPlace { get; set; }
        public int ToPlace { get; set; }
        public List<PlacesResponseModel> Places { get; set; }

        public class PlacesResponseModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

    }
}
