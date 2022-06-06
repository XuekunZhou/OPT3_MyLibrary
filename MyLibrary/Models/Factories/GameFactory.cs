namespace MyLibrary.Models
{
    public class GameFactory : Factory
    {
        public override EntryModel GetEntry()
        {
            return new GameEntryModel{DateOfEntry = DateTime.UtcNow};
        }

        public override SessionModel GetSession()
        {
            return new GameSessionModel{DateOfSession = DateTime.UtcNow};
        }
    }
}