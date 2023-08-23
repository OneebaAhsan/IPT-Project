namespace LibraryAPI.Data
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public float Price { get; set; }
        public string Complexity { get; set; } = string.Empty;
        public string author { get; set; } = string.Empty;
    }
}
