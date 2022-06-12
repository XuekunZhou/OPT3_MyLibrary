namespace MyLibrary.Models
{
    public abstract class OverviewModel
    {
        protected ApplicationDbContext _context;
        protected ApplicationUser _user;

        public string? PeriodString { get; protected set; }
        public int PeriodDays { get; protected set; }
        public int TimeSpentOnFilmsInMinutes { get; protected set; }
        public int EpisodesWatchedOfSeries { get; protected set; }
        public int PagesReadOfBooks { get; protected set; }   
        public int TimeSpentOnGamesInMinutes { get; protected set; }

        public void CreateOverview()
        {
            SetPeriodString();
            SetPeriodDays();
            SetTimeSpentOnFilms();
            SetEpisodesWatchedOfSeries();
            SetPagesReadOfBooks();
            SetTimeSpentOnGames();
        }

        protected abstract void SetPeriodString();
        protected abstract void SetPeriodDays();
        protected void SetTimeSpentOnFilms()
        {
            var date = DateTime.UtcNow.AddDays(PeriodDays);
            var totalTime = _context.FilmEntries.Where(u => u.User == _user).Where(f => f.DateOfEntry >= date).Sum(x => x.Count);
            TimeSpentOnFilmsInMinutes = totalTime;
        }
        protected void SetEpisodesWatchedOfSeries()
        {
            var date = DateTime.UtcNow.AddDays(PeriodDays);
            var totalEpisodes = _context.SeriesSessions.Where(u => u.User == _user).Where(f => f.DateOfSession >= date).Sum(x => x.Count);
            EpisodesWatchedOfSeries = totalEpisodes;
        }
        protected void SetTimeSpentOnGames()
        {
            var date = DateTime.UtcNow.AddDays(PeriodDays);
            var totalTime = _context.GameSessions.Where(u => u.User == _user).Where(f => f.DateOfSession >= date).Sum(x => x.Count);
            TimeSpentOnGamesInMinutes = totalTime;
        }
        protected void SetPagesReadOfBooks()
        {
            var date = DateTime.UtcNow.AddDays(PeriodDays);
            var totalTime = _context.BookSessions.Where(u => u.User == _user).Where(f => f.DateOfSession >= date).Sum(x => x.Count);
            PagesReadOfBooks = totalTime;
        }
    }
}