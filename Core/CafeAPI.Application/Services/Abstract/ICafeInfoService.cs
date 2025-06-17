using CafeAPI.Application.Dtos.CafeInfoDtos;
using CafeAPI.Application.Dtos.ResponseDtos;

namespace CafeAPI.Application.Services.Abstract
{
    public interface ICafeInfoService
    {
        Task<ResponseDto<List<ResultCafeInfoDto>>> GetAllCafeInfos();
        Task<ResponseDto<DetailCafeInfoDto>> GetByIdCafeInfo(int id);
        Task<ResponseDto<object>> CreateCafeInfo(CreateCafeInfoDto createCafeInfoDto);
        Task<ResponseDto<object>> UpdateCafeInfo(UpdateCafeInfoDto updateCafeInfoDto);
        Task<ResponseDto<object>> DeleteCafeInfo(int id);
    }
}
