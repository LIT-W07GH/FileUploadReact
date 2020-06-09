using System.IO;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FileUploadReact.Data
{
    public class ImageUploadDataContextFactory : IDesignTimeDbContextFactory<ImageUploadDataContext>
    {
        public ImageUploadDataContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), $"..{Path.DirectorySeparatorChar}FileUploadReact.Web"))
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true).Build();

            return new ImageUploadDataContext(config.GetConnectionString("ConStr"));
        }
    }
}