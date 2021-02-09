using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Downloader_CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            string type, url, ring, lang = null;
            INI.ReadIniData("MAIN", "type", type);
        }
    }
}
