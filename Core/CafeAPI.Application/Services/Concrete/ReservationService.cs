using AutoMapper;
using CafeAPI.Application.Dtos.ReservationDtos;
using CafeAPI.Application.Dtos.ResponseDtos;
using CafeAPI.Application.Interfaces;
using CafeAPI.Application.Services.Abstract;
using CafeAPI.Domain.Entities;
using CafeAPI.Domain.Enums;
using FluentValidation;

namespace CafeAPI.Application.Services.Concrete
{
    public class ReservationService : IReservationService
    {
        private readonly IGenericRepository<Reservation> _reservationRepository;
        private readonly IGenericRepository<Table> _tableRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateReservationDto> _createReservationValidator;
        private readonly IValidator<UpdateReservationDto> _updateReservationValidator;

        public ReservationService(IGenericRepository<Reservation> reservationRepository, IMapper mapper, IValidator<CreateReservationDto> createReservationValidator, IValidator<UpdateReservationDto> updateReservationValidator, IGenericRepository<Table> tableRepository)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
            _createReservationValidator = createReservationValidator;
            _updateReservationValidator = updateReservationValidator;
            _tableRepository = tableRepository;
        }

        public async Task<ResponseDto<object>> CreateReservation(CreateReservationDto createReservationDto)
        {
            var existTable = await _tableRepository.GetByIdAsync(createReservationDto.TableId);
            if (existTable is null)
                return new ResponseDto<object>
                {
                    IsSuccess = false,
                    Message = "Masa bulunamadı.",
                    ErrorCode = ErrorCodes.NotFound
                };
            

            var validationResult = _createReservationValidator.Validate(createReservationDto);
            if (!validationResult.IsValid)
            {
                return (new ResponseDto<object>
                {
                    IsSuccess = false,
                    Message = string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)),
                    ErrorCode = ErrorCodes.ValidationError
                });
            }

            var reservation = _mapper.Map<Reservation>(createReservationDto);
            reservation.Status = ReservationStatus.Beklemede;
            reservation.CreatedAt = DateTime.Now;
            await _reservationRepository.AddAsync(reservation);
            return new ResponseDto<object>
            {
                IsSuccess = true,
                Data = reservation,
                Message = "Rezervasyon oluşturuldu."
            };
        }

        public async Task<ResponseDto<object>> DeleteReservation(int id)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation == null)
            {
                return new ResponseDto<object>
                {
                    IsSuccess = false,
                    Message = "Rezervasyon bulunamadı.",
                    ErrorCode = ErrorCodes.NotFound
                };
            }
            await _reservationRepository.DeleteAsync(reservation);
            return new ResponseDto<object>
            {
                IsSuccess = true,
                Message = "Rezervasyon silindi."
            };
        }

        public async Task<ResponseDto<List<ResultReservationDto>>> GetAllReservations()
        {
            var reservations = await _reservationRepository.GetAllAsync();
            if (reservations == null || !reservations.Any())
            {
                return new ResponseDto<List<ResultReservationDto>>
                {
                    IsSuccess = false,
                    Data = null,
                    ErrorCode = ErrorCodes.NotFound,
                    Message = "Rezervasyon bulunamadı."
                };
            }
            var result = _mapper.Map<List<ResultReservationDto>>(reservations);
            return new ResponseDto<List<ResultReservationDto>>
            {
                IsSuccess = true,
                Data = result
            };
        }

        public async Task<ResponseDto<DetailReservationDto>> GetByIdReservation(int id)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation == null)
            {
                return new ResponseDto<DetailReservationDto>
                {
                    IsSuccess = false,
                    Data = null,
                    ErrorCode = ErrorCodes.NotFound,
                    Message = "Rezervasyon bulunamadı."
                };
            }
            var result = _mapper.Map<DetailReservationDto>(reservation);
            return new ResponseDto<DetailReservationDto>
            {
                IsSuccess = true,
                Data = result
            };
        }

        public async Task<ResponseDto<object>> UpdateReservation(UpdateReservationDto updateReservationDto)
        {
            var existTable = await _tableRepository.GetByIdAsync(updateReservationDto.TableId);
            if (existTable is null)
                return new ResponseDto<object>
                {
                    IsSuccess = false,
                    Message = "Masa bulunamadı.",
                    ErrorCode = ErrorCodes.NotFound
                };

            var validationResult = _updateReservationValidator.Validate(updateReservationDto);
            if (!validationResult.IsValid)
            {
                return new ResponseDto<object>
                {
                    IsSuccess = false,
                    Message = string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)),
                    ErrorCode = ErrorCodes.ValidationError
                };
            }
            var reservation = await _reservationRepository.GetByIdAsync(updateReservationDto.Id);
            if (reservation == null)
            {
                return new ResponseDto<object>
                {
                    IsSuccess = false,
                    Message = "Rezervasyon bulunamadı.",
                    ErrorCode = ErrorCodes.NotFound
                };
            }
            reservation = _mapper.Map(updateReservationDto, reservation);
            await _reservationRepository.UpdateAsync(reservation);
            return new ResponseDto<object>
            {
                IsSuccess = true,
                Data = reservation,
                Message = "Rezervasyon güncellendi."
            };
        }
    }
}
