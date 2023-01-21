using ProjectZayShop.Models;

namespace ProjectZayShop.DTOs.CategoryDtos
{
	public class CategoryPostDto
	{
		public string Name { get; set; }
		public IFormFile File { get; set; }
	}
}
