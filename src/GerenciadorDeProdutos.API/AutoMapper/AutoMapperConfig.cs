using AutoMapper;
using GerenciadorDeProdutos.API.ViewModels;
using GerenciadorDeProdutos.Domain.Models;

namespace GerenciadorDeProdutos.API.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Product, UpdateProductViewModel>().ReverseMap();
            CreateMap<Category, UpdateCategoryViewModel>().ReverseMap();
        }
    }
}