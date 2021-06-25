using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIB_SWL_Dice_Calculator.DiceModels
{
    sealed public class DefenseRed : DefenseDie
    {
        public DefenseRed()
        {
            NumberOfFaces = 6;
            BlockFaces = 3;
            SurgeFaces = 1;
            BlankFaces = (byte)(NumberOfFaces - (BlockFaces + SurgeFaces));
            MapDice();
        }
    }
}
