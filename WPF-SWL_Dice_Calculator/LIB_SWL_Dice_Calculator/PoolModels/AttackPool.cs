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

        public event EventHandler<List<Die>> DiceAddedOrRemoved;

        public override List<Die> Pool
        {
            get
            {
                lstDiePool.Clear();
                lstDiePool.AddRange(RedDice);
                lstDiePool.AddRange(BlackDice);
                lstDiePool.AddRange(WhiteDice);

                return lstDiePool;
            }
        }

        private List<AttackRed> RedDice = new List<AttackRed>();
        private List<AttackBlack> BlackDice = new List<AttackBlack>();
        private List<AttackWhite> WhiteDice = new List<AttackWhite>();

        public void AddDie(AttackDie dieToAdd)
        {
            switch (dieToAdd.GetType().Name)
            {
                case "AttackRed":
                    break;
                case "AttackBlack":
                    break;
                case "AttackWhite":
                    break;
                default:
                    break;
            }
            DiceAddedOrRemoved?.Invoke(this, Pool);
        }

        public void AddDice(List<AttackDie> diceToAdd)
        {
            foreach (AttackDie die in diceToAdd)
                AddDie(die);
            DiceAddedOrRemoved?.Invoke(this, Pool);
        }

        public void RemoveDie(AttackDie dieToRemove)
        {
            DiceAddedOrRemoved?.Invoke(this, Pool);
        }

        public void RemoveDice(List<AttackDie> diceToRemove)
        {
            foreach (AttackDie die in diceToRemove)
                RemoveDie(die);
            DiceAddedOrRemoved?.Invoke(this, Pool);
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
