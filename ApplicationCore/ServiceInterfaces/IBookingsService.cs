using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IBookingsService
    {
        Task<List<BookingsResponseModel>> GetAllBookings();
        Task<BookingsRegisterResponseModel> CreateBookings(BookingsRegisterRequestModel registerRequestModel);
        Task<BookingsResponseModel> UpdateBookings(UpdateBookingsRequestModel updateRequestModel);
        Task<BookingsResponseModel> DeleteBookings(int id);


    }
}
