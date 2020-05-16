using System;
using System.Collections.Generic;
using System.Text;
using CPMusic.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CPMusic.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Song> Songs { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
