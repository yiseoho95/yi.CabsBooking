using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
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

        public async Task<CabTypes> GetCab(int id)
        {
            var cabs = await _cabRepository.GetByIdAsync(id);
            var cabTypesResponse = new CabTypesResponseModel();

            throw new NotImplementedException();

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

        public async Task<CabTypesRegisterResponseModel> CreateCab(CabTypesRegisterRequestModel registerRequestModel)
        {
            var cab = new CabTypes
            {
                
                Name = registerRequestModel.Name
            };

            var createdCab = await _cabRepository.AddAsync(cab);

            var createdCabResponseModel = new CabTypesRegisterResponseModel
            {
                Id = createdCab.Id,
                Name = createdCab.Name
            };

            return createdCabResponseModel;
        }

        //     return createdUserResponseModel;
        public async Task<CabTypesResponseModel> UpdateCab(UpdateCabTypeRequestModel updateRequestModel)
        {
            var cab = new CabTypes
            {
                Id = updateRequestModel.Id,
                Name = updateRequestModel.Name
            };

            var updatedCab = await _cabRepository.UpdateAsync(cab);

            var updatedCabResponseModel = new CabTypesResponseModel()
            {
                Id = updatedCab.Id,
                Name = updatedCab.Name
            };

            return updatedCabResponseModel;
        }

        public async Task<CabTypesResponseModel> DeleteCab(int id)
        {
            var cab = await _cabRepository.GetByIdAsync(id);

            await _cabRepository.DeleteAsync(cab);

            var deletedCabResponseModel = new CabTypesResponseModel
            {
                Id = cab.Id,
                Name = cab.Name
            };

            return deletedCabResponseModel;
        }


        /*
*
* public async Task<MovieDetailsResponseModel> UpdateMovie(MovieCreateRequest movieCreateRequest)
{
   //var movie = _mapper.Map<Movie>(movieCreateRequest);

   //var createdMovie = await _movieRepository.UpdateAsync(movie);
   //// var movieGenres = new List<MovieGenre>();
   //foreach (var genre in movieCreateRequest.Genres)
   //{
   //    var movieGenre = new MovieGenre { MovieId = createdMovie.Id, GenreId = genre.Id };
   //    await _genresRepository.UpdateAsync(movieGenre);
   //}

   //return _mapper.Map<MovieDetailsResponseModel>(createdMovie);

   throw new NotImplementedException();
}d
*/

    }
}
