using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;

namespace ApplicationCore.ServiceInterfaces
{
    public interface ICabTypesService
    {
        Task<CabTypesResponseModel> GetCabTypesWithBookings(int id);
        Task<List<CabTypesResponseModel>> GetAllCabTypes();
        Task<CabTypesRegisterResponseModel> CreateCab(CabTypesRegisterRequestModel registerRequestModel);
        Task<CabTypesResponseModel> UpdateCab(UpdateCabTypeRequestModel updateRequestModel);
        Task<CabTypes> GetCab(int id);
        Task<CabTypesResponseModel> DeleteCab(int id);

    }
}
