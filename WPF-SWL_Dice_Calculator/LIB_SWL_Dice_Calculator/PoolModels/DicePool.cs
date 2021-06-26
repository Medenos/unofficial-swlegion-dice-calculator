using LIB_SWL_Dice_Calculator.DiceModels;
using LIB_SWL_Dice_Calculator.ResultModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIB_SWL_Dice_Calculator.PoolModels
{
    public abstract class DicePool
    {
        protected List<Die> lstDiePool = new List<Die>();
        abstract public List<Die> Pool { get; }

        /// <summary>
        /// Roll the dice in the pool
        /// </summary>
        /// <returns></returns>
        abstract public DiceResult Roll();

        /// <summary>
        /// Calculate the average of the pool
        /// </summary>
        /// <returns></returns>
        public float GetAverage(bool bCountSurges)
        {
            float fAverage = 0f;

            if (bCountSurges)
                foreach (Die die in Pool)
                    fAverage += die.GetAverage(true);
            else
                foreach (Die die in Pool)
                    fAverage += die.GetAverage();

            return fAverage;
        }
    }
}
