namespace ReadLine.Models
{
    public class Tag
    {
        public long TagId { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Books { get; set; }
    }
}
