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
        public int GenreId { get; set; }
        [Required]
        public DateTime? ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public int NumberInStock { get; set; }
    }
}