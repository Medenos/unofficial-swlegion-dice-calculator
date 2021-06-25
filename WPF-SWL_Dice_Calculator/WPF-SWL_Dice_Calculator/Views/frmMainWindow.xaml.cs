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
using WPF_SWL_Dice_Calculator.Views;

namespace WPF_SWL_Dice_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frmAttack.Content = new pgAttackPool();
            frmDefense.Content = new pgDefensePool();
        }

        private void InitializeTabsWidth()
        {
            double bWidth = (tabsViews.ActualWidth / tabsViews.Items.Count);
            foreach (TabItem tab in tabsViews.Items)
            {
                tab.Width =  bWidth -2;
            }
        }
        private void winMainWindow_ContentRendered(object sender, EventArgs e)
        {
            InitializeTabsWidth();
            ChangeGridBackgroundColor();
        }

        private void winMainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            InitializeTabsWidth();
        }

        private void tabsViews_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeGridBackgroundColor();
        }

        private void ChangeGridBackgroundColor()
        {
            grdMain.Background = ((TabItem)tabsViews.SelectedItem).Background;
        }
    }
}
