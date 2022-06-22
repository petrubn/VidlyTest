using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VidlyTest.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int GenreId { get; set; }
        // public virtual Gender Genre { get; set; }
        public virtual Genre Genre { get; set; }
        public DateTime? AddedDate { get; set; }
        public int StockNumber { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}

/*
public enum Gender
{
    Comedy = 1,
    Drama = 4,
    Adventure = 2,
    Fantasy = 3,
    Trailer = 5,
}
*/
