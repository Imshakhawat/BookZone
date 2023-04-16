using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookZone.Models
{
	public class Book
	{

		[Key]
		public int Id { get; set; }
		[Required]
		public string? Title { get; set; }
		public string? Language { get; set; }
		public string? ImgDir { get; set; } 


		[ForeignKey("Author")]
		public int AuthorId { get; set; }
		public Author Author { get; set; }

	}
}
