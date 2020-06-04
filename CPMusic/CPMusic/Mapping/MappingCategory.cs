using AutoMapper;
using CPMusic.Models;
using CPMusic.ViewModels;

namespace CPMusic.Mapping
{
    public class MappingCategory : Profile
    {
        public MappingCategory()
        {
            CreateMap<Category, CategoryViewModel>();
        }
    }
}