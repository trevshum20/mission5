using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mission4.Models
{
    public class AddMovieModel
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        [Required(ErrorMessage ="Category is required")]

        // Foreign Key relationship
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Director is required")]
        public string Director { get; set; }
        [Required(ErrorMessage = "Rating is required")]
        public string Rating { get; set; }

        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }

    }
}
