using System.Linq;
using AutoMapper;
using CPMusic.Models;
using CPMusic.ViewModels;
using CPMusic.InputModels;
using Microsoft.EntityFrameworkCore.Internal;

namespace CPMusic.Mapping
{
    public class MappingSong : Profile
    {
        public MappingSong()
        {
            // Chuyển đổi thuộc tính từ Song -> SongInputModel
            // ArtistSong artistSongs -> Guid[] artistId
            CreateMap<Song, SongInputModel>()
                .ForMember(
                    viewModel => viewModel.ArtistsId,
                    song => song.MapFrom(song => song.ArtistSongs.Select(artist => artist.ArtistId).ToArray())
                );

            // Chuyển đổi thuộc tính từ SongInputModel -> Song
            // String categoryId -> Category category
            // Guid[] artistId -> ArtistSong artistSongs
            CreateMap<SongInputModel, Song>()
                .ForMember(
                    song => song.Category,
                    vm => vm.MapFrom(vm => new Category { Id = vm.CategoryId })
                )
                .ForMember(
                    song => song.ArtistSongs,
                    vm => vm.MapFrom(vm => vm.ArtistsId.Select(artistId => new ArtistSong
                    {
                        ArtistId = artistId,
                    }))
                );

            // Chuyển đổi thuộc tính từ Song -> SongViewModel
            // Guid id -> String id
            // Category category -> String category
            // ArtistSong artistSongs -> IEnumerable<Artist> artists
            CreateMap<Song, SongViewModel>()
                .ForMember(
                    viewModel => viewModel.Id,
                    song => song.MapFrom(song => song.Id.ToString())
                )
                .ForMember(
                    viewModel => viewModel.Category,
                    song => song.MapFrom(song => song.Category.Name)
                )
                .ForMember(
                    viewModel => viewModel.Artists,
                    song => song.MapFrom(song => song.ArtistSongs.Select(artistSong => artistSong.Artist))
                );
        }
    }
}
