namespace MyLibrary.Models
{
    public class FilmFactory : Factory
    {
        public override EntryModel GetEntry()
        {
            return new FilmEntryModel{DateOfEntry = DateTime.UtcNow};
        }

        public override SessionModel GetSession()
        {
            throw new NotImplementedException();
        }
    }
}