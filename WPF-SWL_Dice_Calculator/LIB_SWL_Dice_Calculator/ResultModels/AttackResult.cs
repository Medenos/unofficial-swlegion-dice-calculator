using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIB_SWL_Dice_Calculator.ResultModels
{
    sealed public class AttackResult : DiceResult
    {
        public byte Hits { get; set; }
        public byte Criticals { get; set; }
    }
}
