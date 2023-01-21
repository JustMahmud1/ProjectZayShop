namespace ProjectZayShop.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Price { get; set; }
		public string Image { get; set; }
		public Category Category { get; set; }
		public int CategoryID { get; set; }
	}
}
