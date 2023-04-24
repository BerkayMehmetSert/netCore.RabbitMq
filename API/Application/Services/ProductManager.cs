using API.Application.RabbitMq;
using API.Application.Repositories;
using API.Application.Requests;
using API.Application.Responses;
using API.Models.Entities;
using AutoMapper;

namespace API.Application.Services
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IRabbitMqProducer _rabbitMqProducer;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductManager(IProductRepository productRepository, IRabbitMqProducer rabbitMqProducer, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _rabbitMqProducer = rabbitMqProducer;
        }

        public async Task<ProductResponse> CreateProduct(CreateProductRequest request)
        {
            var product = _mapper.Map<Product>(request);

            _productRepository.Create(product);
            await _unitOfWork.SaveChangesAsync();

            _rabbitMqProducer.Publish(product);

            return _mapper.Map<ProductResponse>(product);
        }

        public async Task<ProductResponse> UpdateProduct(Guid id, UpdateProductRequest request)
        {
            var product = await GetProduct(id);

            if (product == null) return null;

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;

            _productRepository.Update(product);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ProductResponse>(product);
        }

        public async Task<ProductResponse> DeleteProduct(Guid id)
        {
            var product = await GetProduct(id);

            if (product == null) return null;

            _productRepository.Delete(product);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ProductResponse>(product);
        }

        public async Task<ProductResponse> GetProductById(Guid id)
        {
            var product = await GetProduct(id);

            if (product == null) return null;

            return _mapper.Map<ProductResponse>(product);
        }

        public async Task<List<ProductResponse>> GetProducts()
        {
            var products = await _productRepository.GetAll();

            return _mapper.Map<List<ProductResponse>>(products);
        }

        private async Task<Product> GetProduct(Guid id)
        {
            return await _productRepository.GetById(id);
        }
    }
}
