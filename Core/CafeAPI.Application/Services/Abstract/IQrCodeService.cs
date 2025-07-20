using CafeAPI.Application.Dtos.ResponseDtos;

namespace CafeAPI.Application.Services.Abstract
{
    public interface IQrCodeService
    {
        Task<byte[]> GenerateQrCode(string content);
    }
}
