using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FileUploadReact.Web.Controllers
{
    public class ImagesController : Controller
    {
        public IActionResult GetImage(string fileName)
        {
            byte[] bytes = System.IO.File.ReadAllBytes($"uploads/{fileName}");
            return File(bytes, "image/jpeg"); ///mime types
        }
    }
}