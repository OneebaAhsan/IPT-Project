using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDesktop
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public float Price { get; set; }
        public string Complexity { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string CoverPicturePath { get; set; }
        public byte[] CoverPictureBytes { get; set; }
    }
}
