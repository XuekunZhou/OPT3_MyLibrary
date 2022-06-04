using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Models
{
    public class GameEntryModel: EntryModel
    {
        [Range(0, int.MaxValue)]
        [Display(Name ="Time spent in minutes")]
        public int TimeSpentInMin { get; set; }
    }
}