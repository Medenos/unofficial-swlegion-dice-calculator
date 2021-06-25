using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIB_SWL_Dice_Calculator.DiceModels
{
    sealed public class DefenseWhite : DefenseDie
    {
        public DefenseWhite()
        {
            NumberOfFaces = 6;
            BlockFaces = 1;
            SurgeFaces = 1;
            BlankFaces = (byte)(NumberOfFaces - (BlockFaces + SurgeFaces));
            MapDice();
        }
    }
}
