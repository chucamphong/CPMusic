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

        public IAsyncEnumerable<Song> RandomSongs(int take)
        {
            if (take <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(take), "Số lượng bản ghi cần lấy phải > 0.");
            }
            
            return Context.Songs
                          .Include(song => song.ArtistSongs)
                          .ThenInclude(artistSong => artistSong.Artist)
                          .OrderBy(col => Guid.NewGuid())
                          .Take(take)
                          .AsAsyncEnumerable();
        }
    }
}