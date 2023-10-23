namespace OmicronLibraryProject.Models
{
    public class User
    {
        public int Id { get; set; }
        public string TCIdentityNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Adress { get; set; }
        public ICollection<Loan> Loans { get; set; }


    }
}
