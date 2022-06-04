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
        public DbSet<Friendship> Friendships { get; set; }
        
        public DbSet<FilmEntryModel> FilmEntries { get; set; }
        public DbSet<BookEntryModel> BookEntries { get; set; }
        public DbSet<SeriesEntryModel> SeriesEntries { get; set; }
        public DbSet<GameEntryModel> GameEntries { get; set; }

        public DbSet<SeriesSessionModel> SeriesSessions { get; set; }
        public DbSet<BookSessionModel> BookSessions { get; set; }
        public DbSet<GameSessionModel> GameSessions { get; set; }
    }
