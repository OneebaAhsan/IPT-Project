using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class CreateBookDTO
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(40)]
        public string Category { get; set; }
        
        [Required]
        public float Price { get; set; }

        [Required]
        public string Author { get; set; }

        //[Required]
        //public IFormFile CoverPicture { get; set; }

        public string Complexity { get; set; }

        public string Description { get; set; }
    }

    public class BookDTO : CreateBookDTO
    {
        public int BookId { get; set; }

        //public string CoverPicturePath { get; set; }
    }

    public class UpdateBookDTO: CreateBookDTO
    {

    }
}
