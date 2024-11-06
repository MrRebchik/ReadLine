namespace ReadLine.Models
{
    public enum AgeLimit
    {
        None,
        Age_6,
        Age_12,
        Age_16,
        Age_18,
        Age_21,
    }
    [Flags]
    public enum PublishFormat
    {
        NotPublished = 0,
        Paper = 1,
        EBook = 2,
        AudioBook = 4,
    }
    public class Book
    {
        public long BookId { get; set; }
        public string Title { get; set; }
        public long AuthorId { get; set; }
        public int PublicationYear { get; set; }
        public string Publisher { get; set; } // Издатель
        //public string Cover { get; set; } // cover_Id.png
        public int PagesCount { get; set; }
        public PublishFormat PublishFormat { get; set; }
        public long CategoryId { get; set; }
        public AgeLimit AgeLimit { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}
