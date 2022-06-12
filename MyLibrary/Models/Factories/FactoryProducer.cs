namespace MyLibrary.Models
{
    public static class FactoryProducer
    {
        public static Factory GetFactory(EntryTypes type)
        {   
            switch (type)
            {
                case EntryTypes.Film: return new FilmFactory();
                case EntryTypes.Book: return new BookFactory();
                case EntryTypes.Game: return new GameFactory();
                case EntryTypes.Series: return new SeriesFactory();
                default: throw new ArgumentException("Incorrect factory type specified");
            }
        }
    }
}