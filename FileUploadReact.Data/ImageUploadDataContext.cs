using Microsoft.EntityFrameworkCore;

namespace FileUploadReact.Data
{
    public class ImageUploadDataContext : DbContext
    {
        private readonly string _connectionString;

        public ImageUploadDataContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<UploadedImage> UploadedImages { get; set; }
    }
}