using System.ComponentModel.DataAnnotations;

namespace BookZone.Models
{
	public class Author
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string? Name { get; set; }
		public string? Address { get; set; }
		public string? ImgDir { get; set; }


		public ICollection<Book>? Books { get; set; }

	}
}
