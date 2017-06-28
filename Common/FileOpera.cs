using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class FileOpera
    {
        public static string Content(string path)
        {
            StringBuilder sb = new StringBuilder();
            using (FileStream fs = File.Open(WebPath.WebRoot() + "\\" + path, FileMode.Open))
            {
               
                byte[] b = new byte[1024];
                char[] charData = new Char[1024];
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    Decoder d = Encoding.UTF8.GetDecoder();
                    d.GetChars(b, 0, b.Length, charData, 0);
                    sb.Append(charData);
                }
            }
            return sb.ToString();
        }

    }
}
