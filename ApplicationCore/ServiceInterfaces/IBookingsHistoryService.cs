using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IBookingsHistoryService
    {
        Task<List<BookingsHistoriesResponseModel>> GetAllBookingsHistories();
        Task<BookingsHistoryRegisterResponseModel> CreateHistory(BookingsHistoryRegisterRequestModel registerRequestModel);
        Task<BookingsHistoriesResponseModel> UpdateHistory(UpdateBookingsHistoryRequestModel updateRequestModel);
        Task<BookingsHistory> GetHistory(int id);
        Task<BookingsHistoriesResponseModel> DeleteHistory(int id);

   
    }
}
