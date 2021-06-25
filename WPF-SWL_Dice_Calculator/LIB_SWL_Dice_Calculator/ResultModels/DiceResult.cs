using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIB_SWL_Dice_Calculator.ResultModels
{
    public abstract class DiceResult
    {
        public byte Blanks { get; set; }
        public byte Surges { get; set; }
    }
}
