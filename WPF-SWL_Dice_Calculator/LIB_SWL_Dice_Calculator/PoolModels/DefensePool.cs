using LIB_SWL_Dice_Calculator.DiceModels;
using LIB_SWL_Dice_Calculator.ResultModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIB_SWL_Dice_Calculator.PoolModels
{
    sealed public class DefensePool : DicePool
    {
        public override List<Die> Pool { get => throw new NotImplementedException(); protected set => throw new NotImplementedException(); }

        public override byte GetAverage(bool bCountSurges)
        {
            throw new NotImplementedException();
        }

        public override DiceResult Roll()
        {
            throw new NotImplementedException();
        }
    }
}
