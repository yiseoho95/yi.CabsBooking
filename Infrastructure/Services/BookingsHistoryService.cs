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
    public class BookingsHistoryService : IBookingsHistoryService
    {
        private readonly IAsyncRepository<BookingsHistory> _bookingsHistory;

        public BookingsHistoryService(IAsyncRepository<BookingsHistory> bookingsHistory)
        {
            _bookingsHistory = bookingsHistory;
        }

        public async Task<BookingsHistoryRegisterResponseModel> CreateHistory(BookingsHistoryRegisterRequestModel registerRequestModel)
        {
            var history = new BookingsHistory
            {
                Email = registerRequestModel.Email,
                BookingDate = registerRequestModel.BookingDate,
                BookingTime = registerRequestModel.BookingTime,
                FromPlace = registerRequestModel.FromPlace,
                ToPlace = registerRequestModel.ToPlace,
                PickupAddress = registerRequestModel.PickupAddress,
                Landmark = registerRequestModel.Landmark,
                PickupDate = registerRequestModel.PickupDate,
                PickupTime = registerRequestModel.PickupTime,
                CabTypeId = registerRequestModel.CabTypeId,
                ContactNo = registerRequestModel.ContactNo,
                Status = registerRequestModel.Status,
                Comp_Time = registerRequestModel.Comp_Time,
                Charge = registerRequestModel.Charge,
                Feedback = registerRequestModel.Feedback
            };

            var createdHistory = await _bookingsHistory.AddAsync(history);
            var createdHistoryResponseModel = new BookingsHistoryRegisterResponseModel
            {
                Id = createdHistory.Id,
                Email = createdHistory.Email,
                BookingDate = createdHistory.BookingDate,
                BookingTime = createdHistory.BookingTime,
                FromPlace = createdHistory.FromPlace,
                ToPlace = createdHistory.ToPlace,
                PickupAddress = createdHistory.PickupAddress,
                Landmark = createdHistory.Landmark,
                PickupDate = createdHistory.PickupDate,
                PickupTime = createdHistory.PickupTime,
                CabTypeId = createdHistory.CabTypeId,
                ContactNo = createdHistory.ContactNo,
                Status = createdHistory.Status,
                Comp_Time = createdHistory.Comp_Time,
                Charge = createdHistory.Charge,
                Feedback = createdHistory.Feedback
            };

            return createdHistoryResponseModel;
        }
        public async Task<BookingsHistoriesResponseModel> DeleteHistory(int id)
        {
            var history = await _bookingsHistory.GetByIdAsync(id);
            await _bookingsHistory.DeleteAsync(history);
            var deletedHistoryResponseModel = new BookingsHistoriesResponseModel
            {
                Id = history.Id,
                Email = history.Email,
                BookingDate = history.BookingDate,
                BookingTime = history.BookingTime,
                FromPlace = history.FromPlace,
                ToPlace = history.ToPlace,
                PickupAddress = history.PickupAddress,
                Landmark = history.Landmark,
                PickupDate = history.PickupDate,
                PickupTime = history.PickupTime,
                CabTypeId = history.CabTypeId,
                ContactNo = history.ContactNo,
                Status = history.Status,
                Comp_Time = history.Comp_Time,
                Charge = history.Charge,
                Feedback = history.Feedback
            };

            return deletedHistoryResponseModel;
        }

        public async Task<List<BookingsHistoriesResponseModel>> GetAllBookingsHistories()
        {
            var histories = await _bookingsHistory.ListAllAsync();
            var historiesResponse = new List<BookingsHistoriesResponseModel>();
            foreach (var history in histories)
            {
                historiesResponse.Add(new BookingsHistoriesResponseModel
                {
                    Id = history.Id,
                    Email = history.Email,
                    BookingDate = history.BookingDate,
                    BookingTime = history.BookingTime,
                    FromPlace = history.FromPlace,
                    ToPlace = history.ToPlace,
                    PickupAddress = history.PickupAddress,
                    Landmark = history.Landmark,
                    PickupDate = history.PickupDate,
                    PickupTime = history.PickupTime,
                    CabTypeId = history.CabTypeId,
                    ContactNo = history.ContactNo,
                    Status = history.Status,
                    Comp_Time = history.Comp_Time,
                    Charge = history.Charge,
                    Feedback = history.Feedback
                });
            }

            return historiesResponse;
        }

        public Task<BookingsHistory> GetHistory(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BookingsHistoriesResponseModel> UpdateHistory(UpdateBookingsHistoryRequestModel updateRequestModel)
        {
            var history = new BookingsHistory
            {
                Id = updateRequestModel.Id,
                Email = updateRequestModel.Email,
                BookingDate = updateRequestModel.BookingDate,
                BookingTime = updateRequestModel.BookingTime,
                FromPlace = updateRequestModel.FromPlace,
                ToPlace = updateRequestModel.ToPlace,
                PickupAddress = updateRequestModel.PickupAddress,
                Landmark = updateRequestModel.Landmark,
                PickupDate = updateRequestModel.PickupDate,
                PickupTime = updateRequestModel.PickupTime,
                CabTypeId = updateRequestModel.CabTypeId,
                ContactNo = updateRequestModel.ContactNo,
                Status = updateRequestModel.Status,
                Comp_Time = updateRequestModel.Comp_Time,
                Charge = updateRequestModel.Charge,
                Feedback = updateRequestModel.Feedback
            };

            var updatedHistory = await _bookingsHistory.UpdateAsync(history);

            var updatedHistoriesResponseModel = new BookingsHistoriesResponseModel()
            {
                Id = updatedHistory.Id,
                Email = updatedHistory.Email,
                BookingDate = updatedHistory.BookingDate,
                BookingTime = updatedHistory.BookingTime,
                FromPlace = updatedHistory.FromPlace,
                ToPlace = updatedHistory.ToPlace,
                PickupAddress = updatedHistory.PickupAddress,
                Landmark = updatedHistory.Landmark,
                PickupDate = updatedHistory.PickupDate,
                PickupTime = updatedHistory.PickupTime,
                CabTypeId = updatedHistory.CabTypeId,
                ContactNo = updatedHistory.ContactNo,
                Status = updatedHistory.Status,
                Comp_Time = updatedHistory.Comp_Time,
                Charge = updatedHistory.Charge,
                Feedback = updatedHistory.Feedback
            };

            return updatedHistoriesResponseModel;
        }
        
    }
}
