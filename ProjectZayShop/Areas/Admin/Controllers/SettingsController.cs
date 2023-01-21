using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectZayShop.DAL;
using ProjectZayShop.DTOs.SettingDtos;
using ProjectZayShop.Models;

namespace ProjectZayShop.Areas.Admin.Controllers
{
        [Area("Admin")]
    public class SettingsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SettingsController(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            Settings settings = _context.Settings.FirstOrDefault();
            SettingGetDto settingGetDto = _mapper.Map<SettingGetDto>(settings);
            return View(ViewBag);
        }
    }
}
