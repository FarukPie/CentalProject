using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concreate
{
    public class ImageService : IImageService
    {
        public async Task<string> SaveImageAsync(IFormFile file)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var extension=Path.GetExtension(file.FileName).ToLowerInvariant();
            if(extension!=".jpg"&& extension!=".jpeg"&& extension!=".png")
            {
                throw new ValidationException("The file format must be image");
            }

            var imageName = Guid.NewGuid() + extension;
            var saveLocaation= Path.Combine(currentDirectory,"wwwroot/images", imageName);
            var stream=new FileStream(saveLocaation, FileMode.Create);
            await file.CopyToAsync(stream);
            return "/images/" + imageName;

        }
    }
}
