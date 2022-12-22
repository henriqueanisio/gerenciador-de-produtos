using AutoMapper;
using GerenciadorDeProdutos.Domain.Models;
using GerenciadorDeProdutos.Web.ViewModels;

namespace GerenciadorDeProdutos.Web.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }
    }
}