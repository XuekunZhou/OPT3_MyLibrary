namespace MyLibrary.Models
{
    public static class FactoryProducer
    {
        public static Factory GetFactory(EntryTypes type)
        {   
            if (type == EntryTypes.Film)
                return new FilmFactory();

            if (type == EntryTypes.Book)
                return new BookFactory();

            if (type == EntryTypes.Game)
                return new GameFactory();

            if (type == EntryTypes.Series)
                return new SeriesFactory();
            
            throw new ArgumentException("Incorrect factory type specified");
        }
    }
}