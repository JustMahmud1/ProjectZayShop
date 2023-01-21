using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectZayShop.DTOs.SliderDtos
{
	public class SliderPostDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Slogan { get; set; }
		public string Description { get; set; }
		public string ImageName { get; set; }
		[NotMapped]
		public IFormFile File { get; set; }
	}
}
