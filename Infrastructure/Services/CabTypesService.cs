using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Repositories;

namespace Infrastructure.Services
{
    public class CabTypesService : ICabTypesService
    {
        private readonly IAsyncRepository<CabTypes> _cabRepository;
        private readonly IAsyncRepository<Places> _placeRepository;

        public CabTypesService(IAsyncRepository<CabTypes> cabRepository, IAsyncRepository<Places> placeRepository)
        {
            _cabRepository = cabRepository;
            _placeRepository = placeRepository;
        }

        public async Task<List<CabTypesResponseModel>> GetAllCabTypes()
        {
            var cabs = await _cabRepository.ListAllAsync();
            var cabTypesResponse = new List<CabTypesResponseModel>();
            foreach (var id in cabs)
            {
                cabTypesResponse.Add(new CabTypesResponseModel
                {
                    Id = id.Id,
                    Name = id.Name
                });
            }

            return cabTypesResponse;
        }

        public async Task<CabTypesResponseModel> GetCabTypesWithBookings(int id)
        {
            var cab = await _cabRepository.GetByIdAsync(id);
            var cabBookings = new List<BookingsHistoryResponseModel>();
            
            foreach (var cabTypeId in cab.BookingsHistories)
            {
                cabBookings.Add(new BookingsHistoryResponseModel()
                {
                    Id = cabTypeId.Id,
                    Email = cabTypeId.Email,
                    FromPlace = cabTypeId.FromPlace,
                    ToPlace = cabTypeId.ToPlace
                });
            }

            CabTypesResponseModel cabTypesResponseModel = new CabTypesResponseModel();
            var response = cabTypesResponseModel;
            response.Id = cab.Id;
            response.Name = cab.Name;
            response.Bookings = cabBookings;
            //response.Places = places;


            return response;
        }
    }
}
