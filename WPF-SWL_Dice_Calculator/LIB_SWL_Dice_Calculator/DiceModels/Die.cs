using LIB_SWL_Dice_Calculator.Extensions;
using System;

namespace LIB_SWL_Dice_Calculator.DiceModels
{
    abstract public class Die
    {
        public byte NumberOfFaces { get; protected set; }
        public byte BlankFaces { get; protected set; }
        public byte SurgeFaces { get; protected set; }
        public Result[] DieMapping { get; protected set; }

        /// <summary>
        /// Roles the dice to get a random result depending on the dice properties
        /// </summary>
        /// <returns>The result of the roll</returns>
        public Result Roll()
        {
            Random rdm = new Random();

            return DieMapping[rdm.Next(0,NumberOfFaces)];
        }

        /// <summary>
        /// Get the average value for the die
        /// </summary>
        /// <param name="bCountSurges">Tells if the surge should be counted as hits</param>
        /// <returns>A float value of the number of successful results</returns>
        abstract public float GetAverage(bool? bCountSurges);

        /// <summary>
        /// Maps the die face with depending on the properties
        /// </summary>
        abstract protected void MapDice();

        public enum Result
        {
            Blank,
            Hit,
            Critical,
            Block,
            Surge
        }

        public override string ToString()
        {
            string sReturn = $"{GetType().Name}:\t";
            string sTempDieValue = "";

            for (int i = 0; i < DieMapping.Length; i++)
            {
                sTempDieValue = $"{i + 1}.{DieMapping[i]}".PadCenter("X.Critical".Length + 2);
                sReturn += $"|{sTempDieValue}|";
            }

            return sReturn;
        }
    }
}
