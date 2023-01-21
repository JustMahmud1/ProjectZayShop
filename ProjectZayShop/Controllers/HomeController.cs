using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectZayShop.DTOs.SliderDtos;
using ProjectZayShop.DTOs;
using ProjectZayShop.Models;
using System.Diagnostics;
using ProjectZayShop.DAL;

namespace ProjectZayShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
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
                IsMain=x.IsMain
            }).ToList();
            return View(getAllDto.Items);

        }
    }
}