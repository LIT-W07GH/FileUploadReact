using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploadReact.Web.Models
{
    public class UploadImageViewModel
    {
        public string Description { get; set; }
        public string Base64File { get; set; }
        public string FileName { get; set; }
    }
}
