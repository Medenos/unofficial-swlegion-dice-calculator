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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_SWL_Dice_Calculator.Models;
using WPF_SWL_Dice_Calculator.Views;

namespace WPF_SWL_Dice_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OptionModel _opt = new OptionModel();
        winOption _optWindow = null;
        pgAttackPool _pgAtt = null;
        pgDefensePool _pgDef = null;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeTabsWidth()
        {
            double dHeight = (tabsViews.ActualHeight / 10);
            double dWidth = (tabsViews.ActualWidth / tabsViews.Items.Count);
            foreach (TabItem tab in tabsViews.Items)
            {
                tab.Width = dWidth - 2;
                tab.Height = dHeight;
            }
        }
        private void winMainWindow_ContentRendered(object sender, EventArgs e)
        {
            ReloadAll();
        }

        private void winMainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            InitializeTabsWidth();
        }

        private void tabsViews_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetTabColors();
        }

        private void SetTabColors()
        {
            switch (((TabItem)tabsViews.SelectedItem).Name)
            {
                case "tabAttackPool":
                    grdMain.Background = (SolidColorBrush)FindResource("AttackPoolBrush");
                    tabsViews.Background = (LinearGradientBrush)FindResource("AttackPoolGradient");
                    break;
                case "tabDefensePool":
                    grdMain.Background = (SolidColorBrush)FindResource("DefensePoolBrush");
                    tabsViews.Background = (LinearGradientBrush)FindResource("DefensePoolGradient");
                    break;
                case "tabOptions":
                    grdMain.Background = (SolidColorBrush)FindResource("OptionsBrush");
                    tabsViews.Background = (LinearGradientBrush)FindResource("OptionsGradient");
                    break;
                default:
                    grdMain.Background = (SolidColorBrush)FindResource("AttackPoolBrush");
                    tabsViews.Background = (LinearGradientBrush)FindResource("AttackPoolGradient");
                    break;
            }
        }

        private void LoadPagesContent()
        {

            _pgAtt = new pgAttackPool();
            _pgDef = new pgDefensePool();

            frmAttack.Content = _pgAtt;
            frmDefense.Content = _pgDef;
            //frmOptions.Content = _pgOpt;
        }

        private void LoadTheme()
        {
            switch (_opt.Theme)
            {
                case OptionModel.VisualThemes.Empire:
                    ChangeTheme(new Uri("../Themes/EmpireTheme.xaml", UriKind.Relative));
                    break;
                case OptionModel.VisualThemes.Rebels:
                    ChangeTheme(new Uri("../Themes/RebelTheme.xaml", UriKind.Relative));
                    break;
                case OptionModel.VisualThemes.Republic:
                    ChangeTheme(new Uri("../Themes/RepublicTheme.xaml", UriKind.Relative));
                    break;
                case OptionModel.VisualThemes.Separatists:
                    ChangeTheme(new Uri("../Themes/CISTheme.xaml", UriKind.Relative));
                    break;
                case OptionModel.VisualThemes.Basic:
                    ChangeTheme(new Uri("../Themes/BasicTheme.xaml", UriKind.Relative));
                    break;
                default:
                    ChangeTheme(new Uri("../Themes/BasicTheme.xaml", UriKind.Relative));
                    break;
            }
        }

        private void ChangeTheme(Uri uri)
        {
            Resources.Source = uri;
            _pgAtt.Resources.Source = uri;
            _pgDef.Resources.Source = uri;
        }

        private void ReloadAll()
        {
            _opt = _opt.LoadOptions();
            LoadPagesContent();
            LoadTheme();
            InitializeTabsWidth();
            SetTabColors();
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            if (_optWindow == null)
            {
                _optWindow = new winOption(_opt);
                _optWindow.Owner = this;
                _optWindow.Closed += _optWindow_Closed;
                _optWindow.UpdateOption += _optWindow_UpdateOption;
                _optWindow.Show();
            }
            else
                _optWindow.Activate();
        }

        private void _optWindow_UpdateOption(object sender, OptionModel e)
        {
            e.SaveOptions();
            ReloadAll();
        }

        private void _optWindow_Closed(object sender, EventArgs e)
        {
            _optWindow = null;
        }
    }
}
