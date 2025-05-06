using AutoMapper;
using CafeAPI.Application.Dtos.ResponseDtos;
using CafeAPI.Application.Dtos.TableDtos;
using CafeAPI.Application.Interfaces;
using CafeAPI.Application.Services.Abstract;
using CafeAPI.Domain.Entities;
using FluentValidation;

namespace CafeAPI.Application.Services.Concrete
{
    public class TableService : ITableService
    {
        private readonly IGenericRepository<Table> _tableRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateTableDto> _createTableValidator;
        private readonly IValidator<UpdateTableDto> _updateTableValidator;
        private readonly ITableRepository _tableRepository2;

        public TableService(IGenericRepository<Table> tableRepository, IMapper mapper, IValidator<CreateTableDto> createTableValidator, IValidator<UpdateTableDto> updateTableValidator, ITableRepository tableRepository2)
        {
            _tableRepository = tableRepository;
            _mapper = mapper;
            _createTableValidator = createTableValidator;
            _updateTableValidator = updateTableValidator;
            _tableRepository2 = tableRepository2;
        }

        public async Task<ResponseDto<object>> CreateTable(CreateTableDto createTableDto)
        {
            try
            {
                var validate = await _createTableValidator.ValidateAsync(createTableDto);
                if (!validate.IsValid)
                {
                    return new ResponseDto<object> { IsSuccess = false, Data = null, Message = string.Join(",",validate.Errors.Select(x => x.ErrorMessage)), ErrorCodes = ErrorCodes.ValidationError };
                }
                var checkTable = await _tableRepository.GetByIdAsync(createTableDto.TableNumber);
                if (checkTable != null)
                {
                    return new ResponseDto<object> { IsSuccess = false, Data = null, Message = "Masa zaten mevcut.", ErrorCodes = ErrorCodes.DuplicateError };
                }
                var table = _mapper.Map<Table>(createTableDto);
                await _tableRepository.AddAsync(table);

                return new ResponseDto<object> { IsSuccess = true, Data = table, Message = "Masa başarıyla oluşturuldu." };
            }
            catch (Exception)
            {
                return new ResponseDto<object> { IsSuccess = false, Message = "Bir hata oluştu.", ErrorCodes = ErrorCodes.Exception };
            }
        }

        public async Task<ResponseDto<object>> DeleteTable(int id)
        {
            try
            {
                var rp = await _tableRepository.GetByIdAsync(id);
                if (rp == null)
                {
                    return new ResponseDto<object> { IsSuccess = false, Data = null, Message = "Masa bulunamadı.", ErrorCodes = ErrorCodes.NotFound };
                }
                await _tableRepository.DeleteAsync(rp);
                return new ResponseDto<object> { IsSuccess = true, Data = null, Message = "Masa başarıyla silindi." };

            }
            catch (Exception)
            {
                return new ResponseDto<object> { IsSuccess = false, Message = "Bir hata oluştu.", ErrorCodes = ErrorCodes.Exception };
            }
        }

        public async Task<ResponseDto<List<ResultTableDto>>> GetAllTables()
        {
            try
            {
                var tables = await _tableRepository.GetAllAsync();
                if (tables == null || tables.Count == 0)
                {
                    return new ResponseDto<List<ResultTableDto>> { IsSuccess = false, Data = null, Message = "Masa bulunamadı.", ErrorCodes = ErrorCodes.NotFound };
                }

                var result = _mapper.Map<List<ResultTableDto>>(tables);
                return new ResponseDto<List<ResultTableDto>> { IsSuccess = true, Data = result };
            }
            catch (Exception)
            {
                return new ResponseDto<List<ResultTableDto>> { IsSuccess = false, Message = "Bir hata oluştu.", ErrorCodes = ErrorCodes.Exception };
            }
        }

        public async Task<ResponseDto<DetailTableDto>> GetTableById(int id)
        {
            try
            {
                var table = await _tableRepository.GetByIdAsync(id);
                if (table == null)
                {
                    return new ResponseDto<DetailTableDto>
                    {
                        IsSuccess = false,
                        Data = null,
                        Message = "Masa bulunamadı.",
                        ErrorCodes = ErrorCodes.NotFound
                    };
                }
                var result = _mapper.Map<DetailTableDto>(table);
                return new ResponseDto<DetailTableDto> { IsSuccess = true, Data = result };
            }
            catch (Exception)
            {
                return new ResponseDto<DetailTableDto> { IsSuccess = false, Message = "Bir hata oluştu.", ErrorCodes = ErrorCodes.Exception };
            }
        }

        public async Task<ResponseDto<DetailTableDto>> GetTableByTableNumber(int number)
        {
            try
            {
                var table = await _tableRepository2.GetByTableNumberAsync(number);
                if (table == null)
                {
                    return new ResponseDto<DetailTableDto>
                    {
                        IsSuccess = false,
                        Data = null,
                        Message = "Masa bulunamadı.",
                        ErrorCodes = ErrorCodes.NotFound
                    };
                }
                var result = _mapper.Map<DetailTableDto>(table);
                return new ResponseDto<DetailTableDto> { IsSuccess = true, Data = result };
            }
            catch (Exception)
            {
                return new ResponseDto<DetailTableDto> { IsSuccess = false, Message = "Bir hata oluştu.", ErrorCodes = ErrorCodes.Exception };
            }
        }

        public async Task<ResponseDto<object>> UpdateTable(UpdateTableDto updateTableDto)
        {
            try
            {
                var validate = await _updateTableValidator.ValidateAsync(updateTableDto);
                if (!validate.IsValid)
                {
                    return new ResponseDto<object> { IsSuccess = false, Data = null, Message = string.Join(",", validate.Errors.Select(x => x.ErrorMessage)), ErrorCodes = ErrorCodes.ValidationError };
                }
                var rp = await _tableRepository.GetByIdAsync(updateTableDto.Id);
                var result = _mapper.Map(updateTableDto,rp);
                await _tableRepository.UpdateAsync(result);
                return new ResponseDto<object> { IsSuccess = true, Data = result, Message = "Masa başarıyla güncellendi." };

            }
            catch (Exception)
            {
                return new ResponseDto<object> { IsSuccess = false, Message = "Bir hata oluştu.", ErrorCodes = ErrorCodes.Exception };
            }
        }
    }
}
