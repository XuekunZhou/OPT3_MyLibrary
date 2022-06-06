namespace MyLibrary.Models
{
    public class MonthOverviewModel : OverviewModel
    {
        public MonthOverviewModel(ApplicationDbContext context, ApplicationUser user)
        {
            _context = context;
            _user = user;

            CreateOverview();
        }

        protected override void SetTimeSpentOnFilms()
        {
            var date = DateTime.UtcNow.AddDays(-28);
            var totalTime = _context.FilmEntries.Where(u => u.User == _user).Where(f => f.DateOfEntry >= date).Sum(x => x.Count);
            base.TimeSpentOnFilmsInMinutes = totalTime;
        }

        protected override void SetEpisodesWatchedOfSeries()
        {
            var date = DateTime.UtcNow.AddDays(-28);
            var totalEpisodes = _context.SeriesSessions.Where(u => u.User == _user).Where(f => f.DateOfSession >= date).Sum(x => x.Count);
            EpisodesWatchedOfSeries = totalEpisodes;
        }

        protected override void SetTimeSpentOnGames()
        {
            var date = DateTime.UtcNow.AddDays(-28);
            var totalTime = _context.GameSessions.Where(u => u.User == _user).Where(f => f.DateOfSession >= date).Sum(x => x.Count);
            TimeSpentOnGamesInMinutes = totalTime;
        }

        protected override void SetPagesReadOfBooks()
        {
            var date = DateTime.UtcNow.AddDays(-28);
            var totalTime = _context.BookSessions.Where(u => u.User == _user).Where(f => f.DateOfSession >= date).Sum(x => x.Count);
            PagesReadOfBooks = totalTime;
        }

        protected override void SetPeriod()
        {
            Period = "month";
        }
    }
}