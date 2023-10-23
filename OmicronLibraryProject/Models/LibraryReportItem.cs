namespace OmicronLibraryProject.Models
{
	public class LibraryReportItem
	{
		public string ISBN { get; set; }
		public string BookTitle { get; set; }
		public string userTC { get; set; }
		public TimeSpan TimeOutsideLibrary { get; set; }
	}
}
