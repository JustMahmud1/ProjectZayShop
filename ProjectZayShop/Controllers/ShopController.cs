using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectZayShop.DTOs.CategoryDtos;
using ProjectZayShop.DTOs;
using ProjectZayShop.Models;
using ProjectZayShop.DAL;
using ProjectZayShop.DTOs.ProductDtos;
using AutoMapper;

namespace ProjectZayShop.Controllers
{
	public class ShopController : Controller
	{
		private readonly AppDbContext _context;
		private readonly IMapper _mapper;

        public ShopController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
		{

			IQueryable<Product> products = _context.Products;
			GetAllDto<ProductGetDto> getAllDto = new();
			getAllDto.Items = products.Select(x => new ProductGetDto
			{
				Id = x.Id,
				Name = x.Name,
				Price = x.Price,
				Description = x.Description,
				Category = x.Category,
				Image = x.Image

			}).ToList();

			return View(getAllDto.Items);
		}

		public IActionResult ShopSingle(int Id)
		{
			Product product = _context.Products.Find(Id);
			ProductGetDto productGetDto = _mapper.Map<ProductGetDto>(product);
			return View(productGetDto);
		}
	}
}
