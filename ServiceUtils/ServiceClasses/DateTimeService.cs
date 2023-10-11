using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceUtils
{
    static class DateTimeService
    {
        public static DateTime ReadDateFromConsole(string message)
        {
            var date = string.Empty;
            DateTime dateDateTime;

            do
            {
                Console.WriteLine(message);
                date = Console.ReadLine();
            } while (!DateTime.TryParse(date, out dateDateTime));
            return dateDateTime;
        }
    }
}