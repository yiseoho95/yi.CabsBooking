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
    public class BookingsService : IBookingsService
    {
        private readonly IAsyncRepository<Bookings> _bookingsRepository;

        public BookingsService(IAsyncRepository<Bookings> bookingsRepository)
        {
            _bookingsRepository = bookingsRepository;
        }

        public async Task<BookingsRegisterResponseModel> CreateBookings(BookingsRegisterRequestModel registerRequestModel)
        {
            var booking = new Bookings
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
                Status = registerRequestModel.Status
            };

            var createdBooking = await _bookingsRepository.AddAsync(booking);
            var createdBookingResponseModel = new BookingsRegisterResponseModel
            {
                Id = createdBooking.Id,
                Email = createdBooking.Email,
                BookingDate = createdBooking.BookingDate,
                BookingTime = createdBooking.BookingTime,
                FromPlace = createdBooking.FromPlace,
                ToPlace = createdBooking.ToPlace,
                PickupAddress = createdBooking.PickupAddress,
                Landmark = createdBooking.Landmark,
                PickupDate = createdBooking.PickupDate,
                PickupTime = createdBooking.PickupTime,
                CabTypeId = createdBooking.CabTypeId,
                ContactNo = createdBooking.ContactNo,
                Status = createdBooking.Status
            };

            return createdBookingResponseModel;
        }

        public async Task<BookingsResponseModel> DeleteBookings(int id)
        {
            var booking = await _bookingsRepository.GetByIdAsync(id);
            await _bookingsRepository.DeleteAsync(booking);
            var deletedBookingsResponseModel = new BookingsResponseModel
            {
                Id = booking.Id,
                Email = booking.Email,
                BookingDate = booking.BookingDate,
                BookingTime = booking.BookingTime,
                FromPlace = booking.FromPlace,
                ToPlace = booking.ToPlace,
                PickupAddress = booking.PickupAddress,
                Landmark = booking.Landmark,
                PickupDate = booking.PickupDate,
                PickupTime = booking.PickupTime,
                CabTypeId = booking.CabTypeId,
                ContactNo = booking.ContactNo,
                Status = booking.Status,
            };

            return deletedBookingsResponseModel;

        }

        public async Task<List<BookingsResponseModel>> GetAllBookings()
        {
            var bookings = await _bookingsRepository.ListAllAsync();
            var bookingsResponse = new List<BookingsResponseModel>();
            foreach (var booking in bookings)
            {
                bookingsResponse.Add(new BookingsResponseModel
                {
                    Id = booking.Id,
                    Email = booking.Email,
                    BookingDate = booking.BookingDate,
                    BookingTime = booking.BookingTime,
                    FromPlace = booking.FromPlace,
                    ToPlace = booking.ToPlace,
                    PickupAddress = booking.PickupAddress,
                    Landmark = booking.Landmark,
                    PickupDate = booking.PickupDate,
                    PickupTime = booking.PickupTime,
                    CabTypeId = booking.CabTypeId,
                    ContactNo = booking.ContactNo,
                    Status = booking.Status
                });
            }

            return bookingsResponse;
        }

        public async Task<BookingsResponseModel> UpdateBookings(UpdateBookingsRequestModel updateRequestModel)
        {
            var booking = new Bookings
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
            };

            var updatedBookings = await _bookingsRepository.UpdateAsync(booking);

            var updatedBookingsResponseModel = new BookingsResponseModel()
            {
                Id = updatedBookings.Id,
                Email = updatedBookings.Email,
                BookingDate = updatedBookings.BookingDate,
                BookingTime = updatedBookings.BookingTime,
                FromPlace = updatedBookings.FromPlace,
                ToPlace = updatedBookings.ToPlace,
                PickupAddress = updatedBookings.PickupAddress,
                Landmark = updatedBookings.Landmark,
                PickupDate = updatedBookings.PickupDate,
                PickupTime = updatedBookings.PickupTime,
                CabTypeId = updatedBookings.CabTypeId,
                ContactNo = updatedBookings.ContactNo,
                Status = updatedBookings.Status
            };

            return updatedBookingsResponseModel;
        }

       
    }
}
