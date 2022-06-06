namespace MyLibrary.Models
{
    public abstract class Factory
    {
        public abstract EntryModel GetEntry();
        public abstract SessionModel GetSession();
    }

    public enum EntryTypes
    {
        Film,
        Series,
        Book,
        Game
    }
}