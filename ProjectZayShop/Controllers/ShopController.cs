using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectZayShop.DTOs.CategoryDtos;
using ProjectZayShop.DTOs;
using ProjectZayShop.Models;
using ProjectZayShop.DAL;

namespace ProjectZayShop.Controllers
{
    public class ShopController : Controller
	{
		private readonly AppDbContext _context;

		public ShopController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			IQueryable<Category> categories = _context.Categories;
			GetAllDto<CategoryGetDto> getAllDto = new();
			getAllDto.Items = categories.Select(x => new CategoryGetDto
			{
				Id = x.Id,
				Name = x.Name,
				Image = x.Image,
			}).ToList();
			return View(getAllDto.Items);
		}
	}
}
