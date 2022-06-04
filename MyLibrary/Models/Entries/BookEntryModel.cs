using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Models
{
    public class BookEntryModel: EntryModel
    {
        [Range(0, int.MaxValue)]
        [Display(Name ="Total pages read")]
        public int TotalPagesRead { get; set; }
        public ICollection<BookSessionModel>? Sessions { get; set; }
    }
}