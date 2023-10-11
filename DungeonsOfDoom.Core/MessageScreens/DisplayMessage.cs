using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DungeonsOfDoom.Core
{
    static class DisplayMessage
    {
        static string message;
        static public string Message(string path)
        {
            message = File.ReadAllText(path);
            return message;
        }
    }
}
