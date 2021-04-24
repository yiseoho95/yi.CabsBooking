using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class PlacesRepository : EfRepository<Places>
    {
        public PlacesRepository(CabsBookingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
