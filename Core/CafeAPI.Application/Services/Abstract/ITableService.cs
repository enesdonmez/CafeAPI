using CafeAPI.Application.Dtos.TableDtos;
using CafeAPI.Application.Dtos.ResponseDtos;

namespace CafeAPI.Application.Services.Abstract
{
    public interface ITableService
    {
        Task<ResponseDto<List<ResultTableDto>>> GetAllTables();
        Task<ResponseDto<List<ResultTableDto>>> GetAllActiveTables();
        Task<ResponseDto<List<ResultTableDto>>> GetAllActiveTablesGeneric();
        Task<ResponseDto<DetailTableDto>> GetTableById(int id);
        Task<ResponseDto<DetailTableDto>> GetTableByTableNumber(int number);
        Task<ResponseDto<object>> CreateTable(CreateTableDto createTableDto);
        Task<ResponseDto<object>> UpdateTable(UpdateTableDto updateTableDto);
        Task<ResponseDto<object>> DeleteTable(int id);
        Task<ResponseDto<object>> UpdateTableStatusById(int id);
        Task<ResponseDto<object>> UpdateTableStatusByTableNumber(int tableNumber);

    }
}
