using AutoMapper;
using CafeAPI.Application.Dtos.OrderDtos;
using CafeAPI.Application.Dtos.ResponseDtos;
using CafeAPI.Application.Interfaces;
using CafeAPI.Application.Services.Abstract;
using CafeAPI.Domain.Entities;
using FluentValidation;

namespace CafeAPI.Application.Services.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<OrderItem> _orderItemRepository;
        private readonly IOrderRepository _orderRepository2;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateOrderDto> _createOrderValidator;
        private readonly IValidator<UpdateOrderDto> _updateOrderValidator;

        public OrderService(IGenericRepository<Order> orderRepository, IMapper mapper, IValidator<CreateOrderDto> createOrderValidator, IValidator<UpdateOrderDto> updateOrderValidator, IGenericRepository<OrderItem> orderItemRepository, IOrderRepository orderRepository2)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _createOrderValidator = createOrderValidator;
            _updateOrderValidator = updateOrderValidator;
            _orderItemRepository = orderItemRepository;
            _orderRepository2 = orderRepository2;
        }

        public async Task<ResponseDto<object>> CreateOrder(CreateOrderDto createOrderDto)
        {
            try
            {
                var validate = await _createOrderValidator.ValidateAsync(createOrderDto);
                if (!validate.IsValid)
                {
                    return new ResponseDto<object>
                    {
                        IsSuccess = false,
                        Message = string.Join(",", validate.Errors.Select(x => x.ErrorMessage)),
                        Data = null,
                        ErrorCode = ErrorCodes.ValidationError
                    };
                }
                var order = _mapper.Map<Order>(createOrderDto);
                await _orderRepository.AddAsync(order);
                return new ResponseDto<object>
                {
                    IsSuccess = true,
                    Message = "Sipariş başarıyla oluşturuldu.",
                    Data = order
                };
            }
            catch (Exception)
            {
                return new ResponseDto<object> { IsSuccess = false, Message = "Bir hata oluştu.", ErrorCode = ErrorCodes.Exception };
            }
        }

        public async Task<ResponseDto<object>> DeleteOrder(int id)
        {
            try
            {
                var order = await _orderRepository.GetByIdAsync(id);
                if (order == null)
                {
                    return new ResponseDto<object>
                    {
                        IsSuccess = false,
                        Message = "Sipariş bulunamadı.",
                        Data = null
                    };
                }
                await _orderRepository.DeleteAsync(order);
                return new ResponseDto<object>
                {
                    IsSuccess = true,
                    Message = "Sipariş başarıyla silindi.",
                    Data = null
                };
            }
            catch (Exception)
            {
                return new ResponseDto<object> { IsSuccess = false, Message = "Bir hata oluştu.", ErrorCode = ErrorCodes.Exception };
            }
        }

        public async Task<ResponseDto<List<ResultOrderDto>>> GetAllOrders()
        {
            try
            {
                var orders = await _orderRepository.GetAllAsync();
                var orderItems = await _orderItemRepository.GetAllAsync();
                if (orders == null || orders.Count == 0)
                {
                    return new ResponseDto<List<ResultOrderDto>>
                    {
                        IsSuccess = false,
                        Message = "Siparişler bulunamadı.",
                        Data = null
                    };
                }
                var resultOrders = _mapper.Map<List<ResultOrderDto>>(orders);
                return new ResponseDto<List<ResultOrderDto>>
                {
                    IsSuccess = true,
                    Message = "Siparişler başarıyla getirildi.",
                    Data = resultOrders
                };
            }
            catch (Exception)
            {
                return new ResponseDto<List<ResultOrderDto>> { IsSuccess = false, Message = "Bir hata oluştu.", ErrorCode = ErrorCodes.Exception };
            }
        }

        public async Task<ResponseDto<List<ResultOrderDto>>> GetAllOrdersWithDetail()
        {
            try
            {
                var orders = await _orderRepository2.GetAllOrdersWithDetailAsync();
                if (orders == null || orders.Count == 0)
                {
                    return new ResponseDto<List<ResultOrderDto>>
                    {
                        IsSuccess = false,
                        Message = "Siparişler bulunamadı.",
                        Data = null
                    };
                }
                var resultOrders = _mapper.Map<List<ResultOrderDto>>(orders);
                return new ResponseDto<List<ResultOrderDto>>
                {
                    IsSuccess = true,
                    Message = "Siparişler başarıyla getirildi.",
                    Data = resultOrders
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<ResultOrderDto>> { IsSuccess = false, Message = "Bir hata oluştu.", ErrorCode = ErrorCodes.Exception };
            }
        }

        public async Task<ResponseDto<ResultOrderByIdWithDetailDto>> GetOrderById(int id)
        {
            try
            {
                var order = await _orderRepository2.GetOrderByIdWithDetailAsync(id);
                if (order == null)
                {
                    return new ResponseDto<ResultOrderByIdWithDetailDto>
                    {
                        IsSuccess = false,
                        Message = "Sipariş bulunamadı.",
                        Data = null
                    };
                }
                var resultOrder = _mapper.Map<ResultOrderByIdWithDetailDto>(order);
                return new ResponseDto<ResultOrderByIdWithDetailDto>
                {
                    IsSuccess = true,
                    Message = "Sipariş başarıyla getirildi.",
                    Data = resultOrder
                };
            }
            catch (Exception)
            {
                return new ResponseDto<ResultOrderByIdWithDetailDto> { IsSuccess = false, Message = "Bir hata oluştu.", ErrorCode = ErrorCodes.Exception };
            }
        }

        public async Task<ResponseDto<object>> UpdateOrder(UpdateOrderDto updateOrderDto)
        {
            try
            {
                var validate = await _updateOrderValidator.ValidateAsync(updateOrderDto);
                if (!validate.IsValid)
                {
                    return new ResponseDto<object>
                    {
                        IsSuccess = false,
                        Message = string.Join(",", validate.Errors.Select(x => x.ErrorMessage)),
                        Data = null,
                        ErrorCode = ErrorCodes.ValidationError
                    };
                }
                var order = await _orderRepository.GetByIdAsync(updateOrderDto.Id);
                if (order == null)
                {
                    return new ResponseDto<object>
                    {
                        IsSuccess = false,
                        Message = "Sipariş bulunamadı.",
                        Data = null
                    };
                }
                var resultOrder = _mapper.Map<Order>(updateOrderDto);
                await _orderRepository.UpdateAsync(resultOrder);
                return new ResponseDto<object>
                {
                    IsSuccess = true,
                    Message = "Sipariş başarıyla güncellendi.",
                    Data = resultOrder
                };
            }
            catch (Exception)
            {
                return new ResponseDto<object> { IsSuccess = false, Message = "Bir hata oluştu.", ErrorCode = ErrorCodes.Exception };
            }
        }
    }
}
