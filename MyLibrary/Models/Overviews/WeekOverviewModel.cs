namespace MyLibrary.Models
{
    public class WeekOverviewModel : OverviewModel
    {
        public WeekOverviewModel(ApplicationDbContext context, ApplicationUser user)
        {
            _context = context;
            _user = user;

            CreateOverview();
        }

        protected override void SetTimeSpentOnFilms()
        {
            var date = DateTime.UtcNow.AddDays(-7);
            var totalTime = _context.FilmEntries.Where(u => u.User == _user).Where(f => f.DateOfEntry >= date).Sum(x => x.LengthInMinutes);
            base.TimeSpentOnFilmsInMinutes = totalTime;
        }

        protected override void SetEpisodesWatchedOfSeries()
        {
            var date = DateTime.UtcNow.AddDays(-7);
            var totalEpisodes = _context.SeriesSessions.Where(u => u.User == _user).Where(f => f.DateOfSession >= date).Sum(x => x.NumberOfEpisodesWatches);
            EpisodesWatchedOfSeries = totalEpisodes;
        }

        protected override void SetTimeSpentOnGames()
        {
            var date = DateTime.UtcNow.AddDays(-7);
            var totalTime = _context.GameSessions.Where(u => u.User == _user).Where(f => f.DateOfSession >= date).Sum(x => x.TimeSpentInMinutes);
            TimeSpentOnGamesInMinutes = totalTime;
        }

        protected override void SetPagesReadOfBooks()
        {
            var date = DateTime.UtcNow.AddDays(-7);
            var totalTime = _context.BookSessions.Where(u => u.User == _user).Where(f => f.DateOfSession >= date).Sum(x => x.NumberOfPagesRead);
            PagesReadOfBooks = totalTime;
        }
    }
}