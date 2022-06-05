namespace MyLibrary.Models
{
    public abstract class OverviewModel
    {
        protected ApplicationDbContext _context;
        protected ApplicationUser _user;

        public string? Period { get; set; }
        public int TimeSpentOnFilmsInMinutes { get; protected set; }
        public int EpisodesWatchedOfSeries { get; protected set; }
        public int PagesReadOfBooks { get; protected set; }   
        public int TimeSpentOnGamesInMinutes { get; protected set; }

        public void CreateOverview()
        {
            SetTimeSpentOnFilms();
            SetEpisodesWatchedOfSeries();
            SetPagesReadOfBooks();
            SetTimeSpentOnGames();
            CheckNegatives();
        }

        protected abstract void SetTimeSpentOnFilms();
        protected abstract void SetEpisodesWatchedOfSeries();
        protected abstract void SetTimeSpentOnGames();
        protected abstract void SetPagesReadOfBooks();

        protected void CheckNegatives()
        {
            if (TimeSpentOnFilmsInMinutes < 0) 
            {
                TimeSpentOnFilmsInMinutes = 0;
            }
            
            if (EpisodesWatchedOfSeries < 0)
            { 
                EpisodesWatchedOfSeries = 0;
            }

            if (PagesReadOfBooks < 0) 
            {
                PagesReadOfBooks = 0;
            }

            if (TimeSpentOnGamesInMinutes < 0) 
            {
                TimeSpentOnGamesInMinutes = 0;
            }
        }
    
    }
}