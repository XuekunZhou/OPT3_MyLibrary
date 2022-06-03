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

        public override void CreateOverview()
        {
            Period = "week";
            SetPagesReadOfBooks(7);
            SetTimeSpentOnFilms(7);
            SetTimeSpentOnGamesIn(7);
            SetTimeSpentOnSeries(7);
        }
    }
}