using API.Application.Requests;
using API.Application.Responses;
using API.Models.Entities;
using AutoMapper;

namespace API.Application.Mapper
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, CreateProductRequest>().ReverseMap();
            CreateMap<Product, ProductResponse>().ReverseMap();
        }
    }
}
