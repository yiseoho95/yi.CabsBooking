using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models.Response;

namespace ApplicationCore.ServiceInterfaces
{
    public interface ICabTypesService
    {
        Task<CabTypesResponseModel> GetCabTypesWithBookings(int id);
        Task<List<CabTypesResponseModel>> GetAllCabTypes();
    }
}
