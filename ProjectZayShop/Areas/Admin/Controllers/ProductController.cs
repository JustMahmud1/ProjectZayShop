using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectZayShop.DAL;
using ProjectZayShop.DTOs;
using ProjectZayShop.DTOs.ProductDtos;
using ProjectZayShop.Extensions;
using ProjectZayShop.Models;
namespace ProjectZayShop.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		private readonly AppDbContext _context;
		private readonly IMapper _mapper;
		private readonly IWebHostEnvironment _env;

        public object ProductUpdateDto { get; private set; }

        public ProductController(AppDbContext context, IMapper mapper, IWebHostEnvironment env)
		{
			_context = context;
			_mapper = mapper;
			_env = env;
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
				Description	= x.Description,
				Category= x.Category,
				Image= x.Image
				
			}).ToList();
			return View(getAllDto.Items);
		}

		public IActionResult Create()
		{
			ViewBag.Categories = _context.Categories.ToList();
			return View();
		}

		[HttpPost]
		public IActionResult Create(ProductPostDto productPostDto)
		{
			ViewBag.Categories=_context.Categories.ToList();
			Product product=_mapper.Map<Product>(productPostDto);
			product.Image = productPostDto.File.CreateImage(_env.WebRootPath, "assets/img");
			if(product.Image is null)
			{
				ModelState.AddModelError("", "Can't be null");
				return View();
			}
			_context.Products.Add(product);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Update(int Id)
		{
			Product product = _context.Products.Find(Id);
			ProductUpdateDto
			return View();
		}
	}
}
