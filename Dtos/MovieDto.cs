using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly_MVCProject.Dtos
{
    public class MovieDto : IDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int GenreId { get; set; }

        public GenreDto Genre { get; set; }

        public DateTime DateAdded { get; set; }
        public DateTime? ReleaseDate { get; set; }

        [Range(1, 20)]
        public int NumberInStock { get; set; }
    }
}