using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class EntryModel
    {
        [Key]
        public int Id { get; set; }
        public String? Title { get; set; }

        [Range(0, 10)]
        public int ScoreOutOfTen { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfEntry { get; set; }
        public ApplicationUser User { get; set; }
    }
}