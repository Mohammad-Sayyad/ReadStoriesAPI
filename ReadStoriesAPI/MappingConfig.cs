using AutoMapper;
using ReadStoriesAPI.Models;
using ReadStoriesAPI.Models.Dto;

namespace ReadStoriesAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
