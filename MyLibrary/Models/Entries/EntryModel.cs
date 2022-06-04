#nullable disable
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Models
{
    public abstract class EntryModel
    {
        [Key]
        public int Id { get; set; }
        public String Title { get; set; }

        [Range(0, 10)]
        [Display(Name ="Score")]
        public int ScoreOutOfTen { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Date of entry")]
        public DateTime DateOfEntry { get; set; }
        public ApplicationUser User { get; set; }
    }
}