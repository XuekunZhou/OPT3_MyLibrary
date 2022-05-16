using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class GameEntryModel: EntryModel
    {
        [Range(0, int.MaxValue)]
        public int TimeSpentInMin { get; set; }
    }
}