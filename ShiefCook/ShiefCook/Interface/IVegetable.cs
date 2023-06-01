using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiefCook.Interface
{
    internal interface IVegetable
    {
        string Name { get; }

        int Calories { get; }

        int Weight { get; }

        string Color { get; }
    }
}
