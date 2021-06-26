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

        public event EventHandler<List<Die>> DiceAddedOrRemoved;

        public override List<Die> Pool
        {
            get
            {
                lstDiePool.Clear();
                lstDiePool.AddRange(RedDice);
                lstDiePool.AddRange(WhiteDice);

                return lstDiePool;
            }
        }
        List<DefenseRed> RedDice = new List<DefenseRed>();
        List<DefenseWhite> WhiteDice = new List<DefenseWhite>();


        public void AddDie(DefenseDie dieToAdd)
        {
            DiceAddedOrRemoved?.Invoke(this, Pool);
        }

        public void AddDice(List<DefenseDie> diceToAdd)
        {
            foreach (DefenseDie die in diceToAdd)
                AddDie(die);
            DiceAddedOrRemoved?.Invoke(this, Pool);
        }

        public void RemoveDie(DefenseDie dieToRemove)
        {
            DiceAddedOrRemoved?.Invoke(this, Pool);
        }

        public void RemoveDice(List<DefenseDie> diceToRemove)
        {
            foreach (DefenseDie die in diceToRemove)
                RemoveDie(die);
            DiceAddedOrRemoved?.Invoke(this, Pool);
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
