using AutoMapper;
using ProjectZayShop.DTOs.ProductDtos;
using ProjectZayShop.DTOs.SettingDtos;
using ProjectZayShop.Models;

namespace ProjectZayShop.Profiles
{
	public class Mapper:Profile
	{
		public Mapper()
		{
			CreateMap<Settings, SettingGetDto>();
			CreateMap<ProductPostDto, Product>();
			CreateMap<Product,ProductGetDto>();
		}
	}
}
