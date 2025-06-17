using AutoMapper;
using CafeAPI.Application.Dtos.CafeInfoDtos;
using CafeAPI.Application.Dtos.ResponseDtos;
using CafeAPI.Application.Interfaces;
using CafeAPI.Application.Services.Abstract;
using CafeAPI.Domain.Entities;
using FluentValidation;

namespace CafeAPI.Application.Services.Concrete
{
    public class CafeInfoService : ICafeInfoService
    {
        private readonly IGenericRepository<CafeInfo> _cafeInfoRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCafeInfoDto> _createCafeInfoValidator;
        private readonly IValidator<UpdateCafeInfoDto> _updateCafeInfoValidator;

        public CafeInfoService(IGenericRepository<CafeInfo> cafeInfoRepository, IMapper mapper, IValidator<CreateCafeInfoDto> createCafeInfoValidator, IValidator<UpdateCafeInfoDto> updateCafeInfoValidator)
        {
            _cafeInfoRepository = cafeInfoRepository;
            _mapper = mapper;
            _createCafeInfoValidator = createCafeInfoValidator;
            _updateCafeInfoValidator = updateCafeInfoValidator;
        }

        public async Task<ResponseDto<object>> CreateCafeInfo(CreateCafeInfoDto createCafeInfoDto)
        {
            try
            {
                var  validationResult = await _createCafeInfoValidator.ValidateAsync(createCafeInfoDto);
                if (!validationResult.IsValid)
                {
                    return new ResponseDto<object>
                    {
                        IsSuccess = false,
                        Message = string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)),
                        ErrorCode = ErrorCodes.ValidationError
                    };
                }
                var cafeInfo = _mapper.Map<CafeInfo>(createCafeInfoDto);
                await _cafeInfoRepository.AddAsync(cafeInfo);
                return new ResponseDto<object>
                {
                    IsSuccess = true,
                    Data = cafeInfo,
                    Message = "Kafe bilgisi eklendi."
                };
            }
            catch (Exception)
            {
                return new ResponseDto<object>
                {
                    IsSuccess = false,
                    Data = null,
                    ErrorCode = ErrorCodes.Exception,
                    Message = "Bir hata oluştu."
                };
            }
        }

        public async Task<ResponseDto<object>> DeleteCafeInfo(int id)
        {
            try
            {
                var cafeInfo = await _cafeInfoRepository.GetByIdAsync(id);
                if (cafeInfo == null)
                {
                    return new ResponseDto<object>
                    {
                        IsSuccess = false,
                        Data = null,
                        ErrorCode = ErrorCodes.NotFound,
                        Message = "Kafe bilgisi bulunamadı."
                    };
                }
                await _cafeInfoRepository.DeleteAsync(cafeInfo);
                return new ResponseDto<object>
                {
                    IsSuccess = true,
                    Message = "Kafe bilgisi silindi."
                };
            }
            catch (Exception)
            {
                return new ResponseDto<object>
                {
                    IsSuccess = false,
                    Data = null,
                    ErrorCode = ErrorCodes.Exception,
                    Message = "Bir hata oluştu."
                };
            }
        }

        public async Task<ResponseDto<List<ResultCafeInfoDto>>> GetAllCafeInfos()
        {
            try
            {
                var cafeInfos = await _cafeInfoRepository.GetAllAsync();
                if (cafeInfos == null || !cafeInfos.Any())
                {
                    return new ResponseDto<List<ResultCafeInfoDto>>
                    {
                        IsSuccess = false,
                        Data = null,
                        ErrorCode = ErrorCodes.NotFound,
                        Message = "Kafe bilgisi bulunamadı."
                    };
                }

                var result = _mapper.Map<List<ResultCafeInfoDto>>(cafeInfos);
                return new ResponseDto<List<ResultCafeInfoDto>>
                {
                    IsSuccess = true,
                    Data = result
                };

            }
            catch (Exception)
            {
                return new ResponseDto<List<ResultCafeInfoDto>>
                {
                    IsSuccess = false,
                    Data = null,
                    ErrorCode = ErrorCodes.Exception,
                    Message = "Bir hata oluştu."
                };
            }
        }

        public async Task<ResponseDto<DetailCafeInfoDto>> GetByIdCafeInfo(int id)
        {
            try
            {
                var cafeInfo = await _cafeInfoRepository.GetByIdAsync(id);
                if (cafeInfo == null)
                {
                    return new ResponseDto<DetailCafeInfoDto>
                    {
                        IsSuccess = false,
                        Data = null,
                        ErrorCode = ErrorCodes.NotFound,
                        Message = "Kafe bilgisi bulunamadı."
                    };
                }
                var result = _mapper.Map<DetailCafeInfoDto>(cafeInfo);
                return new ResponseDto<DetailCafeInfoDto>
                {
                    IsSuccess = true,
                    Data = result
                };
            }
            catch (Exception)
            {
                return new ResponseDto<DetailCafeInfoDto>
                {
                    IsSuccess = false,
                    Data = null,
                    ErrorCode = ErrorCodes.Exception,
                    Message = "Bir hata oluştu."
                };
            }
        }

        public async Task<ResponseDto<object>> UpdateCafeInfo(UpdateCafeInfoDto updateCafeInfoDto)
        {
            try
            {
                var validationResult = await _updateCafeInfoValidator.ValidateAsync(updateCafeInfoDto);
                if (!validationResult.IsValid)
                {
                    return new ResponseDto<object>
                    {
                        IsSuccess = false,
                        Message = string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)),
                        ErrorCode = ErrorCodes.ValidationError
                    };
                }

                var cafeInfo = await _cafeInfoRepository.GetByIdAsync(updateCafeInfoDto.Id);
                if (cafeInfo == null)
                {
                    return new ResponseDto<object>
                    {
                        IsSuccess = false,
                        Data = null,
                        ErrorCode = ErrorCodes.NotFound,
                        Message = "Kafe bilgisi bulunamadı."
                    };
                }
                cafeInfo = _mapper.Map(updateCafeInfoDto, cafeInfo);
                await _cafeInfoRepository.UpdateAsync(cafeInfo);
                return new ResponseDto<object>
                {
                    IsSuccess = true,
                    Data = cafeInfo,
                    Message = "Kafe bilgisi güncellendi."
                };
            }
            catch (Exception)
            {
                return new ResponseDto<object>
                {
                    IsSuccess = false,
                    Data = null,
                    ErrorCode = ErrorCodes.Exception,
                    Message = "Bir hata oluştu."
                };
            }
        }
    }
}
