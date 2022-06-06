namespace MyLibrary.Models
{
    public static class Warning
    {
        public static string GetWarning(OverviewModel model)
        {
            var totalTime = model.TimeSpentOnFilmsInMinutes + model.TimeSpentOnGamesInMinutes + model.EpisodesWatchedOfSeries * 45;

            if (totalTime > 1320)
                return "You REALLY should spent less time on this";
            
            if (totalTime > 850)
                return "You should spent less time on this";

            return "";
        }
    }
}