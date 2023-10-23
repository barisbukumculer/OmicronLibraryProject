namespace OmicronLibraryProject.Models
{
    public class Loan
    {
        public int LoanId { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }

        public Book Book { get; set; }
        public User User { get; set; }
    }
}
