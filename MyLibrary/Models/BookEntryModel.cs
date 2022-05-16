using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class BookEntryModel: EntryModel
    {
        [Range(0, int.MaxValue)]
        public int PagesRead { get; set; }
    }
}