using System.Linq;
using AutoMapper;
using CPMusic.InputModels;
using CPMusic.Models;
using CPMusic.ViewModels;

namespace CPMusic.Mapping
{
    public class MappingSong : Profile
    {
        public MappingSong()
        {
            // Chuyển đổi thuộc tính từ Song -> SongUpdateInputModel
            // ArtistSong artistSongs -> Guid[] artistId
            CreateMap<Song, SongUpdateInputModel>()
                .ForMember(
                    viewModel => viewModel.ArtistsId,
                    song => song.MapFrom(song => song.ArtistSongs.Select(artist => artist.ArtistId).ToArray())
                );

            // Chuyển đổi thuộc tính từ SongUpdateInputModel -> Song
            // String categoryId -> Category category
            // Guid[] artistId -> ArtistSong artistSongs
            CreateMap<SongUpdateInputModel, Song>()
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
                )
                .ForMember(
                    song => song.Country,
                    vm => vm.MapFrom(vm => new Country { Id = vm.CountryId })
                );

            // Chuyển đổi thuộc tính từ SongCreateInputModel -> Song
            // String categoryId -> Category category
            // Guid[] artistId -> ArtistSong artistSongs
            CreateMap<SongCreateInputModel, Song>()
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
                )
                .ForMember(
                    viewModel => viewModel.Country,
                    song => song.MapFrom(song => song.Country.Name)
                );
        }
    }
}