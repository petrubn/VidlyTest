using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using VidlyTest.Models;
using VidlyTest.Models;
using DbContext = System.Data.Entity.DbContext;

namespace VidlyTest.ViewModels
{
    public class MovieFormViewModel : DbContext
    {
        public List<Genre> Genres { get; set; }
        /*[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        [Required(ErrorMessage = "Enter customer's name.")] 
        public string? Name { get; set; }
        public int? GenreId { get; set; }
        [Required(ErrorMessage = "Enter Release Date")] 
        public DateTime? ReleaseDate { get; set; }
        [Required(ErrorMessage = "Enter Stock Number")] 
        [Between20StockNumber]
        public int StockNumber { get; set; }
        public static readonly int min = 0;
        public static readonly int max = 20;*/
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int? GenreId { get; set; }
        
        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Added Date")]
        [Required]
        public DateTime? AddedDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required]
        public int? StockNumber { get; set; }
        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }
        /*
         * - ENUM
         * - DB
         * - AFISARE
         * 
         */

        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            StockNumber = movie.StockNumber; 
            GenreId = movie.GenreId;
        }
        
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
