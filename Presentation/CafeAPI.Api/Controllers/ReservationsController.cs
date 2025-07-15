using CafeAPI.Application.Dtos.ReservationDtos;
using CafeAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CafeAPI.Api.Controllers
{
    //[Authorize(Roles = "admin")]
    [Route("api/reservations")]
    [ApiController]
    public class ReservationsController(IReservationService _reservationService) : BaseController
    {
        [EndpointDescription("Rezervasyon bilgilerini listeler.")]
        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            var result = await _reservationService.GetAllReservations();
            return CreateResponse(result);
        }

        [EndpointDescription("Yeni rezervasyon oluşturur.")]
        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationDto request)
        {
            var result = await _reservationService.CreateReservation(request);
            return CreateResponse(result);
        }

        [EndpointDescription("Id ye göre rezervasyon getirir.")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdReservation(int id)
        {
            var result = await _reservationService.GetByIdReservation(id);
            return CreateResponse(result);
        }

        [EndpointDescription("Rezervasyonu günceller.")]
        [HttpPut]
        public async Task<IActionResult> UpdateReservation([FromBody] UpdateReservationDto request)
        {
            var result = await _reservationService.UpdateReservation(request);
            return CreateResponse(result);
        }

        [EndpointDescription("Rezervasyonu siler.")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var result = await _reservationService.DeleteReservation(id);
            return CreateResponse(result);
        }
    }
}
