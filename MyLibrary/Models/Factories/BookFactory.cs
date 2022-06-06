namespace MyLibrary.Models
{
    public class BookFactory : Factory
    {
        public override EntryModel GetEntry()
        {
            return new BookEntryModel{DateOfEntry = DateTime.UtcNow};
        }

        public override SessionModel GetSession()
        {
            return new BookSessionModel{DateOfSession = DateTime.UtcNow};
        }
    }
}