using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly_MVCProject.Models
{
    public class Movie
    {
        public Movie()
        {
            DateAdded=DateTime.Now;
        }

        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public Genre Genre { get; set; }
        
        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        
        [Required]
        [Display(Name="Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name="Date Added")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name="Number in Stock")]
        public int NumberInStock { get; set; }
    }
}