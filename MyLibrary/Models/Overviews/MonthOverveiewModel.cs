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

        public override void CreateOverview()
        {
            Period = "month";
            SetPagesReadOfBooks(28);
            SetTimeSpentOnFilms(28);
            SetTimeSpentOnGamesIn(28);
            SetEpisodesWatchedOfSeries(28);
        }
    }
}