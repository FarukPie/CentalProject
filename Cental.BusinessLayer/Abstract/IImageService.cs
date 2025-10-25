using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Abstract
{
    public interface IImageService
    {
        /// <summary>
        /// save an image file from the compputer to the projects wwwroot/images folder
        /// </summary>
        /// <param name="file"></param>
        /// <returns> returns a string value for the models imageurl property </returns>
        Task<string> SaveImageAsync(IFormFile file);
    }
}
