using System;
using System.Threading.Tasks;
using CPMusic.Data.Interfaces;
using CPMusic.Models;
using Microsoft.EntityFrameworkCore;

namespace CPMusic.Data.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Artist?> GetByIdAsyncWithRelationShip(Guid id)
        {
            return await Query(artist => artist,
                artist => artist.Id == id,
                include: query =>
                {
                    return query.Include(song => song.ArtistSongs)
                                .ThenInclude(artistSong => artistSong.Song);
                }
            ).SingleOrDefaultAsync();
        }
    }
}