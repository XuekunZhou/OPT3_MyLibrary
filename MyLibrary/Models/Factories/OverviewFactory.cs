using Microsoft.AspNetCore.Identity;

namespace MyLibrary.Models
{
    public static class OverviewFactory
    {
        public static OverviewModel GetWeekOverview( ApplicationDbContext _context,  ApplicationUser _user)
        {
            return new WeekOverviewModel(_context, _user);
        }
        
        public static OverviewModel GetTwoWeekOverview( ApplicationDbContext _context,  ApplicationUser _user)
        {
            return new TwoWeekOverviewModel(_context, _user);
        }

        public static OverviewModel GetMonthOverview( ApplicationDbContext _context,  ApplicationUser _user)
        {
            return new MonthOverviewModel(_context, _user);
        }
    }
}