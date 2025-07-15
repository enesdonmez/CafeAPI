using CafeAPI.Application.Dtos.ReservationDtos;
using CafeAPI.Application.Dtos.ResponseDtos;

namespace CafeAPI.Application.Services.Abstract
{
    public interface IReservationService
    {
        Task<ResponseDto<List<ResultReservationDto>>> GetAllReservations();
        Task<ResponseDto<DetailReservationDto>> GetByIdReservation(int id);
        Task<ResponseDto<object>> CreateReservation(CreateReservationDto createReservationDto);
        Task<ResponseDto<object>> UpdateReservation(UpdateReservationDto updateReservationDto);
        Task<ResponseDto<object>> DeleteReservation(int id);
    }
}
