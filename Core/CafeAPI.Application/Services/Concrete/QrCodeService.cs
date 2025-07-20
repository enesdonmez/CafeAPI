using CafeAPI.Application.Dtos.ResponseDtos;
using CafeAPI.Application.Services.Abstract;
using QRCoder;

namespace CafeAPI.Application.Services.Concrete
{
    public class QrCodeService : IQrCodeService
    {
        public Task<byte[]> GenerateQrCode(string content)
        {
            using var qrGenerator = new QRCodeGenerator();
            using var qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
            using var qrCode = new PngByteQRCode(qrCodeData);
            var qrCodeBytes = qrCode.GetGraphic(5);
            return Task.FromResult(qrCodeBytes);
        }
    }
}
