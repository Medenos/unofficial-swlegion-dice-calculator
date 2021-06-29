using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIB_SWL_Dice_Calculator.ResultModels
{
    sealed public class AttackResult : DiceResult
    {
        public int Hits { get; set; }
        public int Criticals { get; set; }
    }
}
