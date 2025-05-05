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

        public TableService(IGenericRepository<Table> tableRepository, IMapper mapper, IValidator<CreateTableDto> createTableValidator, IValidator<UpdateTableDto> updateTableValidator)
        {
            _tableRepository = tableRepository;
            _mapper = mapper;
            _createTableValidator = createTableValidator;
            _updateTableValidator = updateTableValidator;
        }

        public async Task<ResponseDto<object>> CreateTable(CreateTableDto createTableDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<object>> DeleteTable(int id)
        {
            throw new NotImplementedException();
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

        public Task<ResponseDto<DetailTableDto>> GetTableById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<DetailTableDto>> GetTableByTableNumber(int number)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<object>> UpdateTable(UpdateTableDto updateTableDto)
        {
            throw new NotImplementedException();
        }
    }
}
