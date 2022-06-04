namespace MyLibrary.Models
{
    public abstract class OverviewModel
    {
        protected ApplicationDbContext _context;
        protected ApplicationUser _user;

        public string? Period { get; set; }
        public int TimeSpentOnFilmsInMinutes { get; private set; }
        public int EpisodesWatchedOfSeries { get; private set; }
        public int PagesReadOfBooks { get; private set; }   
        public int TimeSpentOnGamesInMinutes { get; private set; }

        public abstract void CreateOverview();

        protected void SetTimeSpentOnFilms(int days)
        {
            var date = DateTime.Now.AddDays(-days);
            var totalTime = _context.FilmEntries.Where(u => u.User == _user).Where(f => f.DateOfEntry >= date).Sum(x => x.LengthInMinutes);
            TimeSpentOnFilmsInMinutes = totalTime;
        }

        protected void SetEpisodesWatchedOfSeries(int days)
        {
            var date = DateTime.Now.AddDays(-days);
            var totalEpisodes = _context.SeriesSessions.Where(u => u.User == _user).Where(f => f.DateOfSession >= date).Sum(x => x.NumberOfEpisodesWatches);
            EpisodesWatchedOfSeries = totalEpisodes;
        }

        protected void SetTimeSpentOnGamesIn(int days)
        {
            var date = DateTime.Now.AddDays(-days);
            var totalTime = _context.GameSessions.Where(u => u.User == _user).Where(f => f.DateOfSession >= date).Sum(x => x.TimeSpentInMinutes);
            TimeSpentOnGamesInMinutes = totalTime;
        }

        protected void SetPagesReadOfBooks(int days)
        {
            var date = DateTime.Now.AddDays(-days);
            var totalTime = _context.BookSessions.Where(u => u.User == _user).Where(f => f.DateOfSession >= date).Sum(x => x.NumberOfPagesRead);
            PagesReadOfBooks = totalTime;
        }
        
    }
}