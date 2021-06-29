using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WPF_SWL_Dice_Calculator.Models
{
    public class OptionModel
    {
        const string SAVE_OPTION_PATH = "./Saves";
        const string SAVE_FILE_NAME = "/SavedOptions.json";
        public VisualThemes Theme { get; set; } = VisualThemes.Basic;
        public bool? Muted { get; set; } = false;

        public OptionModel LoadOptions()
        {
            OptionModel optReturn = new OptionModel();

            if (!File.Exists(SAVE_OPTION_PATH + SAVE_FILE_NAME))
                SaveOptions();

            StreamReader sr = new StreamReader(SAVE_OPTION_PATH + SAVE_FILE_NAME);

            string sJSON = sr.ReadToEnd();
            sr.Close();

            optReturn = JsonConvert.DeserializeObject<OptionModel>(sJSON);

            return optReturn;
        }

        public void SaveOptions()
        {
            if (!Directory.Exists(SAVE_OPTION_PATH))
                Directory.CreateDirectory(SAVE_OPTION_PATH);

            string sJSON = JsonConvert.SerializeObject(this);

            StreamWriter sw = new StreamWriter(SAVE_OPTION_PATH + SAVE_FILE_NAME);

            sw.Write(sJSON);
            sw.Flush();
            sw.Close();
        }

        public enum VisualThemes
        {
            Basic,
            Empire,
            Rebels,
            Republic,
            Separatists
        }
    }
}
