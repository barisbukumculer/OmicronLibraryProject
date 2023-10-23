namespace OmicronLibraryProject.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public bool IsAvailable { get; set; }
        public ICollection<Loan> Loans { get; set; }
    }
}
