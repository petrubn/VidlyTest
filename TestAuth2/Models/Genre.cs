using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VidlyTest.Models
{
    public class Genre
    {
       public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}