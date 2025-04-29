namespace CafeAPI.Application.Dtos.ResponseDtos
{
    public class ResponseDto<T> where T : class
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public string ErrorCodes { get; set; }
    }
   
}
