using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Places
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //NAV PROP
        public ICollection<Bookings> Bookings { get; set; }
        public ICollection<BookingsHistory> BookingsHistories { get; set; }
    }
}
