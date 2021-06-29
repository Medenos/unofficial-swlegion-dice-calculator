using LIB_SWL_Dice_Calculator.DiceModels;
using LIB_SWL_Dice_Calculator.ResultModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIB_SWL_Dice_Calculator.PoolModels
{
    sealed public class AttackPool : DicePool
    {
        public int RedDiceAmount { get; set; }
        public int BlackDiceAmount { get; set; }
        public int WhiteDiceAmount { get; set; }

        public override float GetAverage(bool bSurge)
        {
            float fReturn = 0f;

            //Create a red die and gets its average, then adds the average times the amount to the return value
            AttackDie tempDie = new AttackRed();
            float fTempAverage = 0f;
            fTempAverage = tempDie.GetAverage(bSurge);

            fReturn += fTempAverage * RedDiceAmount;

            //Creates a black die and gets its average, then adds the average times the amount to the return value
            tempDie = new AttackBlack();
            fTempAverage = tempDie.GetAverage(bSurge);

            fReturn += fTempAverage * BlackDiceAmount;

            //Creates a white die and gets its average, then adds the average times the amount to the return value
            tempDie = new AttackWhite();
            fTempAverage = tempDie.GetAverage(bSurge);

            fReturn += fTempAverage * WhiteDiceAmount;

            return fReturn;
        }

        public override DiceResult Roll()
        {

            AttackResult result = new AttackResult();

            //Roll all red dice
            AttackDie tempDie = new AttackRed();
            for (int i = 0; i < RedDiceAmount; i++)
            {
                switch (tempDie.Roll())
                {
                    case Die.Result.Blank:
                        result.Blanks++;
                        break;
                    case Die.Result.Hit:
                        result.Hits++;
                        break;
                    case Die.Result.Critical:
                        result.Criticals++;
                        break;
                    case Die.Result.Surge:
                        result.Surges++;
                        break;
                    default:
                        break;
                }
            }

            //Roll all Black dice
            tempDie = new AttackBlack();
            for (int i = 0; i < BlackDiceAmount; i++)
            {
                switch (tempDie.Roll())
                {
                    case Die.Result.Blank:
                        result.Blanks++;
                        break;
                    case Die.Result.Hit:
                        result.Hits++;
                        break;
                    case Die.Result.Critical:
                        result.Criticals++;
                        break;
                    case Die.Result.Surge:
                        result.Surges++;
                        break;
                    default:
                        break;
                }
            }

            //Roll all White dice
            tempDie = new AttackWhite();
            for (int i = 0; i < WhiteDiceAmount; i++)
            {
                switch (tempDie.Roll())
                {
                    case Die.Result.Blank:
                        result.Blanks++;
                        break;
                    case Die.Result.Hit:
                        result.Hits++;
                        break;
                    case Die.Result.Critical:
                        result.Criticals++;
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
