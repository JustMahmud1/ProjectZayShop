using ProjectZayShop.Models;

namespace ProjectZayShop.DTOs.ProductDtos
{
	public class ProductPostDto
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string Price { get; set; }
		public IFormFile File { get; set; }
		public Category Category { get; set; }
		public int CategoryID { get; set; }
	}
}
