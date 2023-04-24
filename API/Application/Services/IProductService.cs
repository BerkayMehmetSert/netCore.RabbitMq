using API.Application.Requests;
using API.Application.Responses;

namespace API.Application.Services
{
    public interface IProductService
    {
        Task<ProductResponse> CreateProduct(CreateProductRequest request);
        Task<ProductResponse> UpdateProduct(Guid id, UpdateProductRequest request);
        Task<ProductResponse> DeleteProduct(Guid id);
        Task<ProductResponse> GetProductById(Guid id);
        Task<List<ProductResponse>> GetProducts();
    }
}
