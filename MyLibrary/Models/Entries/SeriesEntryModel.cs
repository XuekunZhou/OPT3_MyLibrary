using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Models
{
    public class SeriesEntryModel: EntryModel
    {
        public ICollection<SessionModel>? Episodes { get; set; }
    }
}