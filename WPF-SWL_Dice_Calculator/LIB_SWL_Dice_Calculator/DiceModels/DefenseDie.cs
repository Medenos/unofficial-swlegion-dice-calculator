using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIB_SWL_Dice_Calculator.DiceModels
{
    abstract public class DefenseDie : Die
    {
        public byte BlockFaces { get; protected set; }

        public override float GetAverage(bool? bCountSurges)
        {
            float fReturn = 0f;

            if (bCountSurges == true)
                fReturn =((float)BlockFaces + (float)SurgeFaces) / (float)NumberOfFaces;
            else
                fReturn = (float)BlockFaces / (float)NumberOfFaces;

            return fReturn;
        }

        protected override void MapDice()
        {
            DieMapping = new Result[NumberOfFaces];

            //Sets the mapping for the hit faces
            for (int i = 0; i < BlockFaces; i++)
                DieMapping[i] = Result.Block;

            //Sets the mapping for the surge faces
            for (int i = BlockFaces; i < BlockFaces + SurgeFaces; i++)
                DieMapping[i] = Result.Surge;

            //Sets the mapping for the blank faces
            for (int i = BlockFaces + SurgeFaces; i < NumberOfFaces; i++)
                DieMapping[i] = Result.Blank;
        }


    }
}
