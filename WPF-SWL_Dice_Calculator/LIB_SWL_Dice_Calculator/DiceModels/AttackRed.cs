using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIB_SWL_Dice_Calculator.DiceModels
{
    sealed public class AttackRed : AttackDie
    {
        public AttackRed()
        {
            NumberOfFaces = 8;
            HitFaces = 5;
            CriticalFaces = 1;
            SurgeFaces = 1;
            BlankFaces = (byte)(NumberOfFaces - (HitFaces + CriticalFaces + SurgeFaces));
            MapDice();
        }
    }
}
