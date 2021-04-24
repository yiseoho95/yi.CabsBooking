using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;

namespace Infrastructure.Services
{
    public class PlacesService : IPlacesService
    {
        private readonly IAsyncRepository<Places> _placeRepository;

        public PlacesService(IAsyncRepository<Places> placeRepository)
        {
            _placeRepository = placeRepository;
        }
        public async Task<PlacesRegisterResponseModel> CreatePlace(PlacesRegisterRequestModel registerRequestModel)
        {
            var place = new Places
            {
                Name = registerRequestModel.Name
            };

            var createdPlace = await _placeRepository.AddAsync(place);
            var createdPlaceResponseModel = new PlacesRegisterResponseModel
            {
                Id = createdPlace.Id,
                Name = createdPlace.Name
            };

            return createdPlaceResponseModel;
            
        }

        public async Task<PlacesResponseModel> DeletePlace(int id)
        {
            var place = await _placeRepository.GetByIdAsync(id);
            await _placeRepository.DeleteAsync(place);
            var deletedPlaceResponseModel = new PlacesResponseModel
            {
                Id = place.Id,
                Name = place.Name
            };

            return deletedPlaceResponseModel;
        }


        public async Task<List<PlacesResponseModel>> GetAllPlaces()
        {
            var places = await _placeRepository.ListAllAsync();
            var placesResponse = new List<PlacesResponseModel>();
            foreach (var place in places)
            {
                placesResponse.Add(new PlacesResponseModel
                {
                    Id = place.Id,
                    Name = place.Name
                });
            }

            return placesResponse;
        }

        public Task<Places> GetPlace(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PlacesResponseModel> UpdatePlace(UpdatePlacesRequestModel updateRequestModel)
        {
            var places = new Places
            {
                Id = updateRequestModel.Id,
                Name = updateRequestModel.Name
            };

            var updatedPlace = await _placeRepository.UpdateAsync(places);

            var updatedPlacesResponseModel = new PlacesResponseModel()
            {
                Id = updatedPlace.Id,
                Name = updatedPlace.Name
            };
            return updatedPlacesResponseModel;
        }


    }
}
