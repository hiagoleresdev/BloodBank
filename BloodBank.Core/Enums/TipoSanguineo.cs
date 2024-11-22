using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Enums
{
    public enum TipoSanguineo
    {
        [Description("A")]
        A = 1,  
        [Description("B")]
        B = 2,
        [Description("AB")]
        AB = 3,
        [Description("O")]
        O  = 4,
    }
}
