using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDataDemo
{
    public class FileHandler
    {
        public void GetManyFiles()
        {
            var folderPath = Directory.GetCurrentDirectory() + "\\DataFiles";

            foreach (var path in Directory.GetFiles(folderPath))
            {
                var fileName = Path.GetFileName(path);
                File.ReadAllText(path);
            }
        }
    }
}
