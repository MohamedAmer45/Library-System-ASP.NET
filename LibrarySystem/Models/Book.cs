using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Book
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Book Title")]
        [Required(ErrorMessage = "Enter a Valid Title")]
        [MinLength(1, ErrorMessage = "The Book Title mustn't be less than 1 character")]
        [MaxLength(300)]
        public string BookTitle { get; set; }
        [DisplayName("Author")]
        [Required(ErrorMessage = "Enter a Valid Author Name")]
        [MinLength(2, ErrorMessage = "The Author Name mustn't be less than 2 characters")]
        [MaxLength(60)]
        public string Author { get; set; }
        [DisplayName("ISBN")]
        [Required(ErrorMessage = "Enter a Valid ISBN")]
        [MinLength(13, ErrorMessage = "ISBN must be 13 digits")]
        [MaxLength(13)]
        public string ISBN { get; set; }

        [DisplayName("Page Count")]
        [Required(ErrorMessage = "Enter a Valid Number of Pages")]
        [Range(50, 2500, ErrorMessage = "Page Count Must be Between 50 and 2500")]
        public int Pages { get; set; }
    }
}
