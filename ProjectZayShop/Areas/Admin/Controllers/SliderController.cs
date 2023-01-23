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

        public IActionResult Update(int Id)
        {
            Slider slider = _context.Sliders.Find(Id);
            SliderUpdateDto sliderUpdateDto = new SliderUpdateDto()
            {
                sliderGetDto = new SliderGetDto()
                {
                    Id=slider.Id,
                    Name = slider.Name,
                    Slogan = slider.Slogan,
                    Description = slider.Description
                }
            };
            return View(sliderUpdateDto);
        }

        [HttpPost]
        public IActionResult Update(SliderUpdateDto sliderUpdateDto)
        {
            Slider slider = _context.Sliders.Find(sliderUpdateDto.sliderGetDto.Id);
            slider.Name=sliderUpdateDto.sliderPostDto.Name;
            slider.Slogan = sliderUpdateDto.sliderPostDto.Slogan;
            slider.Description = sliderUpdateDto.sliderPostDto.Description;
            if(sliderUpdateDto.sliderGetDto.ImageName!=null)
            {
                slider.ImageName = sliderUpdateDto.sliderPostDto.File.CreateImage(_environment.WebRootPath, "assets/img");
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int Id)
        {
			Slider slider = _context.Sliders.Find(Id);
            _context.Sliders.Remove(slider);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
		}



        
    }

}
