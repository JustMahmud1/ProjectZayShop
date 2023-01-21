using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectZayShop.DAL;
using ProjectZayShop.DTOs;
using ProjectZayShop.DTOs.SliderDtos;
using ProjectZayShop.Extensions;
using ProjectZayShop.Models;
using System.Reflection.Metadata;

namespace ProjectZayShop.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SliderController : Controller
	{
		private readonly AppDbContext _context;
		private readonly IMapper _mapper;
		private readonly IWebHostEnvironment _environment;

        public SliderController(AppDbContext context, IMapper mapper,IWebHostEnvironment environment)
        {
            _context = context;
            _mapper = mapper;
            _environment = environment;
        }

        public IActionResult Index()
		{
            IQueryable<Slider> sliders = _context.Sliders;
            GetAllDto<SliderGetDto> getAllDto = new();
            getAllDto.Items = sliders.Select(x => new SliderGetDto
            {
                Id = x.Id,
                Name = x.Name,
                Slogan = x.Slogan,
                Description = x.Description,
                ImageName = x.ImageName,
            }).ToList();
            return View(getAllDto.Items);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
		public IActionResult Create(SliderPostDto sliderPostDto)
        {
            
            _context.Sliders.Add(new Slider
            {
                Name = sliderPostDto.Name,
                Slogan = sliderPostDto.Slogan,
                Description = sliderPostDto.Description,
                ImageName = sliderPostDto.File.CreateImage(_environment.WebRootPath,"assets/img")
            });
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        
    }

}
