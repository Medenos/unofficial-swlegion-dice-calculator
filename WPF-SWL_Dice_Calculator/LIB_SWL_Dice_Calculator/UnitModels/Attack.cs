using LIB_SWL_Dice_Calculator.PoolModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIB_SWL_Dice_Calculator.UnitModels
{
    public class Attack
    {
        public string Name { get; set; }
        public AttackPool Pool { get; set; }
        public List<Keyword> Keywords { get; set; }
        public byte MinRange { get; set; }
        public byte MaxRange { get; set; }
    }
}
