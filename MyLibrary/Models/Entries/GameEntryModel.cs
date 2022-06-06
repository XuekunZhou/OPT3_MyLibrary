using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Models
{
    public class GameEntryModel: EntryModel
    {
        public ICollection<SessionModel>? Sessions { get; set; }
    }
}