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
        public int RedDiceAmount { get; set; }
        public int WhiteDiceAmount { get; set; }

        public override float GetAverage(bool bSurge)
        {
            float fReturn = 0f;

            //Create a red die and gets its average, then adds the average times the amount to the return value
            DefenseDie tempDie = new DefenseRed();
            float fTempAverage = 0f;
            fTempAverage = tempDie.GetAverage(bSurge);

            fReturn += fTempAverage * RedDiceAmount;

            //Creates a white die and gets its average, then adds the average times the amount to the return value
            tempDie = new DefenseWhite();
            fTempAverage = tempDie.GetAverage(bSurge);

            fReturn += fTempAverage * WhiteDiceAmount;

            return fReturn;
        }

        public override DiceResult Roll()
        {
            DefenseResult result = new DefenseResult();

            //Roll all red dice
            DefenseDie tempDie = new DefenseRed();
            for (int i = 0; i < RedDiceAmount; i++)
            {

                switch (tempDie.Roll())
                {
                    case Die.Result.Blank:
                        result.Blanks++;
                        break;
                    case Die.Result.Block:
                        result.Blocks++;
                        break;
                    case Die.Result.Surge:
                        result.Surges++;
                        break;
                    default:
                        break;
                }
            }

            //Roll all white dice
            tempDie = new DefenseWhite();
            for (int i = 0; i < WhiteDiceAmount; i++)
            {

                switch (tempDie.Roll())
                {
                    case Die.Result.Blank:
                        result.Blanks++;
                        break;
                    case Die.Result.Block:
                        result.Blocks++;
                        break;
                    case Die.Result.Surge:
                        result.Surges++;
                        break;
                    default:
                        break;
                }
            }

            return result;
        }
    }
}
