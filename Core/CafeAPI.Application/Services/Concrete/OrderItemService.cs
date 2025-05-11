using AutoMapper;
using CafeAPI.Application.Dtos.OrderItemDtos;
using CafeAPI.Application.Dtos.ResponseDtos;
using CafeAPI.Application.Interfaces;
using CafeAPI.Application.Services.Abstract;
using CafeAPI.Domain.Entities;
using FluentValidation;

namespace CafeAPI.Application.Services.Concrete
{
    public class OrderItemService : IOrderItemItemService
    {
        private readonly IGenericRepository<OrderItem> _orderItemRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateOrderItemDto> _createOrderItemValidator;
        private readonly IValidator<UpdateOrderItemDto> _updateOrderItemValidator;

        public OrderItemService(IGenericRepository<OrderItem> orderItemRepository, IMapper mapper, IValidator<CreateOrderItemDto> createOrderItemValidator, IValidator<UpdateOrderItemDto> updateOrderItemValidator)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
            _createOrderItemValidator = createOrderItemValidator;
            _updateOrderItemValidator = updateOrderItemValidator;
        }

        public async Task<ResponseDto<object>> CreateOrderItem(CreateOrderItemDto createOrderItemDto)
        {
            try
            {
                var validationResult = await _createOrderItemValidator.ValidateAsync(createOrderItemDto);
                if (!validationResult.IsValid)
                {
                    return new ResponseDto<object>
                    {
                        IsSuccess = false,
                        Message = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage)),
                        Data = null,
                        ErrorCode = ErrorCodes.ValidationError
                    };
                }
                var orderItem = _mapper.Map<OrderItem>(createOrderItemDto);
                await _orderItemRepository.AddAsync(orderItem);
                return new ResponseDto<object>
                {
                    IsSuccess = true,
                    Message = "Sipariş öğesi başarıyla oluşturuldu",
                    Data = orderItem
                };
            }
            catch (Exception)
            {
                return new ResponseDto<object>
                {
                    IsSuccess = false,
                    Message = "bir sorun oluştu",
                    Data = null,
                    ErrorCode = ErrorCodes.Exception
                };
            }
        }
        public async Task<ResponseDto<object>> DeleteOrderItem(int id)
        {
            try
            {
                var orderItem = await _orderItemRepository.GetByIdAsync(id);
                if (orderItem == null)
                {
                    return new ResponseDto<object>
                    {
                        IsSuccess = false,
                        Message = "Sipariş öğesi bulunamadı",
                        Data = null,
                        ErrorCode = ErrorCodes.NotFound
                    };
                }
                await _orderItemRepository.DeleteAsync(orderItem);
                return new ResponseDto<object>
                {
                    IsSuccess = true,
                    Message = "Sipariş öğesi başarıyla silindi",
                    Data = null
                };

            }
            catch (Exception)
            {
                return new ResponseDto<object>
                {
                    IsSuccess = false,
                    Message = "bir sorun oluştu",
                    Data = null,
                    ErrorCode = ErrorCodes.Exception
                };
            }
        }
        public async Task<ResponseDto<List<ResultOrderItemDto>>> GetAllOrderItems()
        {
            try
            {
                var orderItems = await _orderItemRepository.GetAllAsync();
                if (orderItems == null || orderItems.Count == 0)
                {
                    return new ResponseDto<List<ResultOrderItemDto>>
                    {
                        IsSuccess = false,
                        Message = "Sipariş öğesi bulunamadı",
                        Data = null,
                        ErrorCode = ErrorCodes.NotFound
                    };
                }
                var resultOrderItems = _mapper.Map<List<ResultOrderItemDto>>(orderItems);
                return new ResponseDto<List<ResultOrderItemDto>>
                {
                    IsSuccess = true,
                    Message = "",
                    Data = resultOrderItems
                };
            }
            catch (Exception)
            {
                return new ResponseDto<List<ResultOrderItemDto>>
                {
                    IsSuccess = false,
                    Message = "bir sorun oluştu",
                    Data = null,
                    ErrorCode = ErrorCodes.Exception
                };
            }
        }
        public async Task<ResponseDto<DetailOrderItemDto>> GetOrderItemById(int id)
        {
            try
            {
                var orderItem = await _orderItemRepository.GetByIdAsync(id);
                if (orderItem == null)
                    return new ResponseDto<DetailOrderItemDto>
                    {
                        IsSuccess = false,
                        Message = "Sipariş itemi bulunamadı",
                        Data = null,
                        ErrorCode = ErrorCodes.NotFound
                    };

                var resultOrderItem = _mapper.Map<DetailOrderItemDto>(orderItem);
                return new ResponseDto<DetailOrderItemDto>
                {
                    IsSuccess = true,
                    Message = "",
                    Data = resultOrderItem
                };
            }
            catch (Exception)
            {
                return new ResponseDto<DetailOrderItemDto>
                {
                    IsSuccess = false,
                    Message = "bir sorun oluştu",
                    Data = null,
                    ErrorCode = ErrorCodes.Exception
                };
            }
        }
        public async Task<ResponseDto<object>> UpdateOrderItem(UpdateOrderItemDto updateOrderItemDto)
        {
            try
            {
                var validationResult = await _updateOrderItemValidator.ValidateAsync(updateOrderItemDto);
                if (!validationResult.IsValid)
                {
                    return new ResponseDto<object>
                    {
                        IsSuccess = false,
                        Message = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage)),
                        Data = null,
                        ErrorCode = ErrorCodes.ValidationError
                    };
                }
                var orderItem = await _orderItemRepository.GetByIdAsync(updateOrderItemDto.Id);
                if (orderItem == null)
                {
                    return new ResponseDto<object>
                    {
                        IsSuccess = false,
                        Message = "Sipariş öğesi bulunamadı",
                        Data = null,
                        ErrorCode = ErrorCodes.NotFound
                    };
                }
                var result = _mapper.Map(updateOrderItemDto, orderItem);
                await _orderItemRepository.UpdateAsync(orderItem);
                return new ResponseDto<object>
                {
                    IsSuccess = true,
                    Message = "Sipariş öğesi başarıyla güncellendi",
                    Data = orderItem
                };
            }
            catch (Exception)
            {
                return new ResponseDto<object>
                {
                    IsSuccess = false,
                    Message = "bir sorun oluştu",
                    Data = null,
                    ErrorCode = ErrorCodes.Exception
                };
            }
        }
    }
}
