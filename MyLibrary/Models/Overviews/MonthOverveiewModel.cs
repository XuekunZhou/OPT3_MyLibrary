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

        protected override void SetPeriodDays()
        {
            PeriodDays = 28;
        }

        protected override void SetPeriodString()
        {
            PeriodString = "month";
        }
    }
}