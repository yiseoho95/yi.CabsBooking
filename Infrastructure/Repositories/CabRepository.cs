using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CabRepository : EfRepository<CabTypes>
    {
        public CabRepository(CabsBookingDbContext dbContext) : base(dbContext)
        {
        }
        
        public override async Task<CabTypes> GetByIdAsync(int id)
        {
            var cabTypes = await _dbContext.CabTypes.Where(c => c.Id == id).Include(c => c.BookingsHistories)
                .ThenInclude(c => c.Places).FirstOrDefaultAsync();
            
            return cabTypes;
        }
    }
}

