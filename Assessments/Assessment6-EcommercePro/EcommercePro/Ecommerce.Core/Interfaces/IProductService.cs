using Ecommerce.Core.DTOs;

namespace Ecommerce.Core.Interfaces
{
    public interface IProductService
    {
        Task<ProductResponseDTO> AddProductAsync(ProductRequestDTO user);
        Task UpdateProductAsync(int id, ProductRequestDTO user);
        Task DeleteProductAsync(int id);
        Task<List<ProductResponseDTO>> GetAllProductsAsync();
        Task<ProductResponseDTO?> GetProductByIdAsync(int id);
    }
}
