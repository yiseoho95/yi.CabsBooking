using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class BookingsHistoryRepository : EfRepository<BookingsHistory>
    {
        public BookingsHistoryRepository(CabsBookingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
