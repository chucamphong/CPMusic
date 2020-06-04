﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPMusic.Data.Interfaces;
using CPMusic.Models;
using Microsoft.EntityFrameworkCore;

namespace CPMusic.Data.Repositories
{
    public class SongRepository : Repository<Song>, ISongRepository
    {
        public SongRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Song> Update(Song song)
        {
            // Dùng để xóa hết những nghệ sĩ đang có quan hệ với bài hát để phục vụ cho việc cập nhật lại ca sĩ
            // Nếu không sẽ dẫn đến bị trùng khóa ca sĩ
            // Note: Chưa tìm được cách nào hay hơn nên phải dùng cách củ chuối này
            Context.Set<ArtistSong>().RemoveRange(
                await Context.Set<ArtistSong>().Where(artistSong => artistSong.SongId == song.Id).ToListAsync()
            );

            return await base.Update(song);
        }

        public async Task<IEnumerable<Song>> RandomSongs(int take = 0)
        {
            return await All(song => song,
                include: query =>
                {
                    return query.Include(song => song.ArtistSongs)
                                .ThenInclude(artistSong => artistSong.Artist);
                },
                orderBy: query => query.OrderBy(song => Guid.NewGuid()),
                take: take
            );
        }

        public async Task<IEnumerable<Song>> Ranking(int take = 0)
        {
            return await All(song => song,
                include: query =>
                {
                    return query.Include(song => song.ArtistSongs)
                                .ThenInclude(artistSong => artistSong.Artist);
                },
                orderBy: query => query.OrderByDescending(song => song.Views),
                take: take
            );
        }

        public async Task<IEnumerable<Song>> NewSongsReleased(int take = 0)
        {
            return await All(song => song,
                include: query =>
                {
                    return query.Include(song => song.ArtistSongs)
                                .ThenInclude(artistSong => artistSong.Artist);
                },
                orderBy: query => query.OrderByDescending(song => song.CreatedAt),
                take: take
            );
        }
    }
}