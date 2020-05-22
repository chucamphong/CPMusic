using System;
using System.Collections.Generic;
using System.Linq;
using CPMusic.Data.Interfaces;
using CPMusic.Models;

namespace CPMusic.Data.Repositories
{
    public class SongRepository : Repository<Song>, ISongRepository
    {
        public SongRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
