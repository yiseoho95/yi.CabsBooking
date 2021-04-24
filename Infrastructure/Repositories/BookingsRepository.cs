using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class BookingsRepository : EfRepository<Bookings>
    {
        public BookingsRepository(CabsBookingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
