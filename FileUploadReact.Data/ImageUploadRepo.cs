using System.Collections.Generic;
using System.Linq;

namespace FileUploadReact.Data
{
    public class ImageUploadRepo
    {
        private readonly string _connectionString;

        public ImageUploadRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(UploadedImage image)
        {
            using (var context = new ImageUploadDataContext(_connectionString))
            {
                context.UploadedImages.Add(image);
                context.SaveChanges();
            }
        }

        public List<UploadedImage> GetAll()
        {
            using (var context = new ImageUploadDataContext(_connectionString))
            {
                return context.UploadedImages.ToList();
            }
        }
    }
}