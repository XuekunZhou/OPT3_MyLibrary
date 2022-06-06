namespace MyLibrary.Models
{
    public class SeriesFactory : Factory
    {
        public override EntryModel GetEntry()
        {
            return new SeriesEntryModel{DateOfEntry = DateTime.UtcNow};
        }

        public override SessionModel GetSession()
        {
            return new SeriesSessionModel{DateOfSession = DateTime.UtcNow};
        }
    }
}