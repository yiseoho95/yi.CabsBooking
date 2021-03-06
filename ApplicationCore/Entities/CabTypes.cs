using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApplicationCore.Entities
{
    public class CabTypes
    {
      
        public int Id { get; set; }
        public string Name { get; set; }

        //NAV PROP
        public ICollection<Bookings> Bookings { get; set; }
        public ICollection<BookingsHistory> BookingsHistories { get; set; }
    }
}
