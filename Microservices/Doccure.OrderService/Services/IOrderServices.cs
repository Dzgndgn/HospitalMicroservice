using Doccure.OrderService.Dtos.OrderDtos;

namespace Doccure.OrderService.Services
{
    public interface IOrderServices
    {
        Task CreateOrderAsync(CreateOrderDto createOrderDto);
        Task<List<ResultOrderDto>> GetAllOrderAsync();
        Task<GetByIdOrderDto> GetByIdOrderAsync(int id);
    }
}
