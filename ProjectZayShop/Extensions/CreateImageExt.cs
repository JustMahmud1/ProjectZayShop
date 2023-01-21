using ProjectZayShop.DTOs.SliderDtos;

namespace ProjectZayShop.Extensions
{
	public static class CreateImageExt
	{
		public static string CreateImage(this IFormFile formFile, string environment, string path)
		{
			string imgname = Guid.NewGuid() + formFile.FileName;
			string FullPath = Path.Combine(environment, path, imgname);
			using (FileStream fileStream = new FileStream(FullPath, FileMode.Create))
			{
				formFile.CopyTo(fileStream);
			}
			return imgname;
		}
	}
}
