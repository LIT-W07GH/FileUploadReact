using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FileUploadReact.Data;
using FileUploadReact.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FileUploadReact.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private string _connectionString;

        public UploadController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }

        [HttpPost]
        [Route("addimage")]
        public void AddImage(UploadImageViewModel viewModel)
        {
            int firstComma = viewModel.Base64File.IndexOf(',');
            string base64 = viewModel.Base64File.Substring(firstComma + 1);
            byte[] fileContents = Convert.FromBase64String(base64);

            Guid g = Guid.NewGuid();
            var ext = Path.GetExtension(viewModel.FileName);
            var fileName = $"{g}{ext}";
            System.IO.File.WriteAllBytes($"uploads/{fileName}", fileContents);

            var repo = new ImageUploadRepo(_connectionString);
            repo.Add(new UploadedImage
            {
                Description = viewModel.Description,
                FileName = fileName
            });
        }

        [HttpGet]
        [Route("getall")]
        public List<UploadedImage> GetAll()
        {
            var repo = new ImageUploadRepo(_connectionString);
            return repo.GetAll();
        }
    }
}