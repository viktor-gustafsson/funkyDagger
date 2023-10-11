using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core.Interfaces
{
    public interface IGetMinMax
    {
        string MinMaxReturn { get; set; }
        string GetMinMax();
    }
}
