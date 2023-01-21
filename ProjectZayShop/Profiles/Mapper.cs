using AutoMapper;
using NuGet.Configuration;
using ProjectZayShop.DTOs.SettingDtos;

namespace ProjectZayShop.Profiles
{
	public class Mapper:Profile
	{
		public Mapper()
		{
			CreateMap<Settings, SettingGetDto>();
		}
	}
}
