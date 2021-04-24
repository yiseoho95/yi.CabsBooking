using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IPlacesService
    {
        Task<List<PlacesResponseModel>> GetAllPlaces();
        Task<PlacesRegisterResponseModel> CreatePlace(PlacesRegisterRequestModel registerRequestModel);
        Task<PlacesResponseModel> UpdatePlace(UpdatePlacesRequestModel updateRequestModel);
        Task<Places> GetPlace(int id);
        Task<PlacesResponseModel> DeletePlace(int id);

    }
}
