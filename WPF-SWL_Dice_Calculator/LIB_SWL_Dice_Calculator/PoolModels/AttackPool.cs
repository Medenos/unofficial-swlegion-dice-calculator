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
        public int TotalDiceAmount { get => RedDiceAmount + BlackDiceAmount + WhiteDiceAmount; }
        public int RedDiceAmount { get; set; }
        public int BlackDiceAmount { get; set; }
        public int WhiteDiceAmount { get; set; }
        public int CriticalAmount { get; set; }

        public override float GetAverage(bool? bSurge)
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

            if (bSurge != true && CriticalAmount > 0)
            {
                if (CriticalAmount <= TotalDiceAmount)
                    for (int i = 0; i < CriticalAmount; i++)
                        fReturn += (float)((float)1 / (float)8);

                else
                    for (int i = 0; i < TotalDiceAmount; i++)
                        fReturn += (float)((float)1 / (float)8);
            }
            return fReturn;
        }

        public override DiceResult GetAverageResult()
        {
            AttackResult resultReturn = new AttackResult();

            AttackDie tempDie = new AttackRed();

            resultReturn.Hits += ((AttackResult)(tempDie.GetAverageResult())).Hits * RedDiceAmount;
            resultReturn.Surges += ((AttackResult)(tempDie.GetAverageResult())).Surges * RedDiceAmount;
            resultReturn.Blanks += ((AttackResult)(tempDie.GetAverageResult())).Blanks * RedDiceAmount;
            resultReturn.Criticals += ((AttackResult)(tempDie.GetAverageResult())).Criticals * RedDiceAmount;

            tempDie = new AttackBlack();

            resultReturn.Hits += ((AttackResult)(tempDie.GetAverageResult())).Hits * BlackDiceAmount;
            resultReturn.Surges += ((AttackResult)(tempDie.GetAverageResult())).Surges * BlackDiceAmount;
            resultReturn.Blanks += ((AttackResult)(tempDie.GetAverageResult())).Blanks * BlackDiceAmount;
            resultReturn.Criticals += ((AttackResult)(tempDie.GetAverageResult())).Criticals * BlackDiceAmount;

            tempDie = new AttackWhite();

            resultReturn.Hits += ((AttackResult)(tempDie.GetAverageResult())).Hits * WhiteDiceAmount;
            resultReturn.Surges += ((AttackResult)(tempDie.GetAverageResult())).Surges * WhiteDiceAmount;
            resultReturn.Blanks += ((AttackResult)(tempDie.GetAverageResult())).Blanks * WhiteDiceAmount;
            resultReturn.Criticals += ((AttackResult)(tempDie.GetAverageResult())).Criticals * WhiteDiceAmount;

            return resultReturn;
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
