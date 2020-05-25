using AutoMapper;
using CPMusic.Models;
using CPMusic.Models.ViewModels;

namespace CPMusic.Mapping
{
    public class MappingUser : Profile
    {
        public MappingUser()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}
