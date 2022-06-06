using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Models
{
    public class BookEntryModel: EntryModel
    {
        public ICollection<SessionModel>? Sessions { get; set; }
    }
}