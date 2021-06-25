using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIB_SWL_Dice_Calculator.DiceModels
{
    sealed public class AttackBlack : AttackDie
    {
        public AttackBlack()
        {
            NumberOfFaces = 8;
            HitFaces = 3;
            CriticalFaces = 1;
            SurgeFaces = 1;
            BlankFaces = (byte)(NumberOfFaces - (HitFaces + CriticalFaces + SurgeFaces));
            MapDice();
        }
    }
}
