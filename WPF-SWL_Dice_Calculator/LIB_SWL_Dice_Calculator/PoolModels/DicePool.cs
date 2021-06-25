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
        /// <summary>
        /// A list with all the dice in the pool
        /// </summary>
        abstract public List<Die> Pool { get; protected set; }

        /// <summary>
        /// Roll the dice in the pool
        /// </summary>
        /// <returns></returns>
        abstract public DiceResult Roll();

        /// <summary>
        /// Calculate the average of the pool
        /// </summary>
        /// <returns></returns>
        abstract public byte GetAverage(bool bCountSurges);
    }
}
