using Doccure.MarketService.Dtos.ProductDtos;

namespace Doccure.MarketService.Services.ProductServices
{
    public interface IProductServices
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<GetByIdProductDto> GetByIdProductAsync(int id);
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(int id);
    }
}
