using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIB_SWL_Dice_Calculator.DiceModels
{
    abstract public class AttackDie : Die
    {
        public byte HitFaces { get; protected set; }
        public byte CriticalFaces { get; protected set; }

        public override float GetAverage(bool? bCountSurges)
        {
            float fReturn = 0f;

            if (bCountSurges == true)
                fReturn = ((float)SurgeFaces + (float)CriticalFaces + (float)HitFaces) / (float)NumberOfFaces;
            else
                fReturn = ((float)CriticalFaces + (float)HitFaces) / (float)NumberOfFaces;

            return fReturn;
        }

        protected override void MapDice()
        {
            DieMapping = new Result[NumberOfFaces];

            //Sets the mapping for the hit faces
            for (int i = 0; i < HitFaces; i++)
                DieMapping[i] = Result.Hit;

            //Sets the mapping for the critical faces
            for (int i = HitFaces; i < HitFaces + CriticalFaces; i++)
                DieMapping[i] = Result.Critical;

            //Sets the mapping for the surge faces
            for (int i = HitFaces + CriticalFaces; i < HitFaces + CriticalFaces + SurgeFaces; i++)
                DieMapping[i] = Result.Surge;

            //Sets the mapping for the blank faces
            for (int i = HitFaces + CriticalFaces + SurgeFaces; i < NumberOfFaces; i++)
                DieMapping[i] = Result.Blank;
        }
    }
}
