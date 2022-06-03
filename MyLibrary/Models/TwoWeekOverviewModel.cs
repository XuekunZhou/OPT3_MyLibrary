namespace MyLibrary.Models
{
    public class TwoWeekOverviewModel : OverviewModel
    {
        public TwoWeekOverviewModel(ApplicationDbContext context, ApplicationUser user)
        {
            _context = context;
            _user = user;

            CreateOverview();
        }

        public override void CreateOverview()
        {
            Period = "two weeks";
            SetPagesReadOfBooks(14);
            SetTimeSpentOnFilms(14);
            SetTimeSpentOnGamesIn(14);
            SetTimeSpentOnSeries(14);
        }
    }
}