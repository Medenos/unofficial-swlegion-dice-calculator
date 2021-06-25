using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SWL_Dice_Calculator.Models
{
    public class OptionModel
    {
        public VisualThemes Theme { get; set; } = VisualThemes.Basic;
        public float RollVolume { get; set; } = 0f;

        public OptionModel LoadOptions()
        {
            OptionModel optReturn = new OptionModel();

            return optReturn;
        }

        public void SaveOptions()
        {

        }

        public enum VisualThemes
        {
            Empire,
            Rebels,
            Republic,
            Separatists,
            Basic
        }
    }
}
