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
        public void AddDie(AttackDie dieToAdd)
        {
            Pool.Add(dieToAdd);
        }

        public void AddDice(List<AttackDie> diceToAdd)
        {
            foreach (AttackDie die in diceToAdd)
                AddDie(die);
        }

        public void RemoveDie(AttackDie dieToRemove)
        {
            if (Pool.Contains(dieToRemove))
                Pool.Remove(dieToRemove);
        }

        public void RemoveDice(List<AttackDie> diceToRemove)
        {
            foreach (AttackDie die in diceToRemove)
                RemoveDie(die);
        }

        public override DiceResult Roll()
        {

            AttackResult result = new AttackResult();

            foreach (AttackDie die in Pool)
            {
                switch (die.Roll())
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
