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

        protected override void SetPeriodDays()
        {
            PeriodDays = 14;
        }

        protected override void SetPeriodString()
        {
            PeriodString = "two weeks";
        }
    }
}