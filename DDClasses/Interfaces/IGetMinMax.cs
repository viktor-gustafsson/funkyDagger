﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    interface IGetMinMax
    {
        string MinMaxReturn { get; set; }
        string GetMinMax();
    }
}
