namespace MyLibrary.Models
{
    public class OverviewViewModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ApplicationUser _user;
    
        public int TimePeriodInDays { get; private set; }
        public int TimeSpentOnFilmsInMinutes { get; private set; }
        public int EpisodesWatchedOfSeries { get; private set; }
        public int TimeSpentOnSeries { get; private set; }
        public int PagesReadOfBooks { get; private set; }   
        public int TimeSpentOnGames { get; private set; }

        public OverviewViewModel(ApplicationDbContext context, ApplicationUser user, int timePeriodInDays)
        {
            _context = context;
            _user = user;
            TimePeriodInDays = timePeriodInDays;
            GetTimeSpentOnFilmsInMinutes();
        }

        private void GetTimeSpentOnFilmsInMinutes()
        {
            var date = DateTime.Now.AddDays(-TimePeriodInDays);
            var totalTime = _context.FilmEntries.Where(u => u.User == _user).Where(f => f.DateOfEntry >= date).ToList().Sum(x => x.LengthInMinutes);
            TimeSpentOnFilmsInMinutes = totalTime;
        }
    }
}