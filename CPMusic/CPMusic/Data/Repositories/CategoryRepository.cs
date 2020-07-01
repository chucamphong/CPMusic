using System;
using System.Threading.Tasks;
using CPMusic.Data.Interfaces;
using CPMusic.Models;
using Microsoft.EntityFrameworkCore;

namespace CPMusic.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Category?> GetByIdAsyncWithRelationShip(Guid id)
        {
            return await Query(artist => artist,
                artist => artist.Id == id,
                include: query =>
                {
                    return query.Include(category => category.Songs)
                                .ThenInclude(song => song.ArtistSongs)
                                .ThenInclude(artistSong => artistSong.Artist);
                }
            ).SingleOrDefaultAsync();
        }
    }
}