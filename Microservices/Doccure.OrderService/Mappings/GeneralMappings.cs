using AutoMapper;
using Doccure.OrderService.Dtos.OrderDetailDtos;
using Doccure.OrderService.Dtos.OrderDtos;
using Doccure.OrderService.Entities;

namespace Doccure.OrderService.Mappings
{
    public class GeneralMappings : Profile
    {
        public GeneralMappings()
        {
            CreateMap<CreateOrderDto, Order>().ReverseMap();
            CreateMap<Order, GetByIdOrderDto>().ReverseMap();
            CreateMap<Order, ResultOrderDto>().ReverseMap();

            CreateMap<OrderDetail, ResultOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, CreateOrderDetailDto>().ReverseMap();
        }
    }
}
