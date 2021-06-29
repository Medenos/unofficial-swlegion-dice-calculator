using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_SWL_Dice_Calculator.Models;

namespace WPF_SWL_Dice_Calculator.Views
{
    /// <summary>
    /// Interaction logic for winOption.xaml
    /// </summary>
    public partial class winOption : Window
    {

        OptionModel _opt = new OptionModel();
        public event EventHandler<OptionModel> UpdateOption;
        const int MAX_SOUND = 99;
        const int MIN_SOUND = 0;

        public winOption(OptionModel opt)
        {
            InitializeComponent();
            _opt = opt;
            cmbTheme.ItemsSource = Enum.GetValues(typeof(OptionModel.VisualThemes));
            DataContext = _opt;
        }

        private void cmbTheme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateOption?.Invoke(this, _opt);
        }

    }
}
