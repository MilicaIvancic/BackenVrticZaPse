using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.helpers
{
    public class FileUpload
    {
        public static IEnumerable<string> AllowedExtensions => new List<string> { ".jpeg", ".jpg", ".gif", ".png" };
    }
}
