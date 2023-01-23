using Microsoft.AspNetCore.Mvc;
using ProjectZayShop.DAL;
using ProjectZayShop.DTOs;
using ProjectZayShop.DTOs.CategoryDtos;
using ProjectZayShop.DTOs.SliderDtos;
using ProjectZayShop.Extensions;
using ProjectZayShop.Models;

namespace ProjectZayShop.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{
		private readonly AppDbContext _context;
		private readonly IWebHostEnvironment _env;

		public CategoryController(AppDbContext context, IWebHostEnvironment env)
		{
			_context = context;
			_env = env;
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

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(CategoryPostDto categoryPostDto)
		{
			_context.Categories.Add(new Category
			{
				Name = categoryPostDto.Name,
				Image = categoryPostDto.File.CreateImage(_env.WebRootPath,"assets/img"),
			});
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Update(int Id)
		{
			Category category = _context.Categories.Find(Id);
			CategoryUpdateDto categoryUpdateDto = new CategoryUpdateDto()
			{
				categoryGetDto = new CategoryGetDto() { Id = category.Id, Name = category.Name, Image = category.Image }
			};
			return View(categoryUpdateDto);
		}

		[HttpPost]
		public IActionResult Update(CategoryUpdateDto categoryUpdateDto)
		{
			Category category = _context.Categories.Find(categoryUpdateDto.categoryGetDto.Id);
			category.Name = categoryUpdateDto.categoryPostDto.Name;
			if(categoryUpdateDto.categoryPostDto.File!= null)
			{
				category.Image=categoryUpdateDto.categoryPostDto.File.CreateImage(_env.WebRootPath,"assets/img");
			}
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
		public IActionResult Delete(int Id)
		{
			Category category = _context.Categories.Find(Id);
			_context.Categories.Remove(category);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
	}
}
