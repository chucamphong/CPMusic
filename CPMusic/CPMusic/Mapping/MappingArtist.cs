using AutoMapper;
using CPMusic.InputModels;
using CPMusic.Models;

namespace CPMusic.Mapping
{
    public class MappingArtist : Profile
    {
        public MappingArtist()
        {
            CreateMap<Artist, ArtistUpdateInputModel>();

            CreateMap<ArtistUpdateInputModel, Artist>();
            
            CreateMap<ArtistCreateInputModel, Artist>();
        }
    }
}