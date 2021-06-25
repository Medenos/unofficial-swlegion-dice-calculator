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
        public void AddDie(DefenseDie dieToAdd)
        {
            Pool.Add(dieToAdd);
        }

        public void AddDice(List<DefenseDie> diceToAdd)
        {
            foreach (DefenseDie die in diceToAdd)
                AddDie(die);
        }

        public void RemoveDie(DefenseDie dieToRemove)
        {
            if (Pool.Contains(dieToRemove))
                Pool.Remove(dieToRemove);
        }

        public void RemoveDice(List<DefenseDie> diceToRemove)
        {
            foreach (DefenseDie die in diceToRemove)
                RemoveDie(die);
        }

        public override DiceResult Roll()
        {
            DefenseResult result = new DefenseResult();

            foreach (DefenseDie die in Pool)
            {
                switch (die.Roll())
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
