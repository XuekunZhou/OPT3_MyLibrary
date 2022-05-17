using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Models;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Friend> Friends { get; set; }
        
        public DbSet<FilmEntryModel> FilmEntries { get; set; }
        public DbSet<BookEntryModel> BookEntries { get; set; }
        public DbSet<SeriesEntryModel> SeriesEntries { get; set; }
        public DbSet<EpisodeEntryModel> EpisodeEntries { get; set; }
        public DbSet<GameEntryModel> GameEntries { get; set; }
    }
