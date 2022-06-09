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

        protected override void SetPeriodDays()
        {
            PeriodDays = 7;
        }

        protected override void SetPeriodString()
        {
            PeriodString = "week";
        }
    }
}