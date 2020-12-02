using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionHelper.Models
{
    public class FileInformation
    {
        public FileInformation()
        {
        }

        public FileInformation(string fileName, string filePath)
        {
            FileName = fileName;
            FilePath = filePath;
        }

        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string EnglishName => CultureInfo.CreateSpecificCulture(FileName).EnglishName;
        public string NativeName => CultureInfo.CreateSpecificCulture(FileName).NativeName;
    }
}
