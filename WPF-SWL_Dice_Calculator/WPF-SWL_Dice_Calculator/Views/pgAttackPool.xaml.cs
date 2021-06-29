using LIB_SWL_Dice_Calculator.PoolModels;
using LIB_SWL_Dice_Calculator.DiceModels;
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

namespace WPF_SWL_Dice_Calculator.Views
{
    /// <summary>
    /// Interaction logic for pgAttackPool.xaml
    /// </summary>
    public partial class pgAttackPool : Page
    {
        AttackPool _pool = null;
        const int UPPER_BOUND = 99;
        const int LOWER_BOUND = 0;

        public pgAttackPool()
        {
            InitializeComponent();
            _pool = new AttackPool();
        }

        private void txtRed_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            txtRed.Text = CheckTextBound(txtRed.Text, e);
        }
        private void txtRed_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValid(((TextBox)sender).Text + e.Text);
        }
        private void txtRed_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshPool();
        }


        private void txtBlack_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            txtBlack.Text = CheckTextBound(txtBlack.Text, e);
        }
        private void txtBlack_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValid(((TextBox)sender).Text + e.Text);
        }
        private void txtBlack_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshPool();
        }


        private void txtWhite_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            txtWhite.Text = CheckTextBound(txtWhite.Text, e);
        }
        private void txtWhite_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValid(((TextBox)sender).Text + e.Text);
        }
        private void txtWhite_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshPool();
        }

        #region Functions
        private bool IsValid(string sInput)
        {
            if (sInput != null)
            {
                int i;
                return int.TryParse(sInput, out i) && i >= LOWER_BOUND && i <= UPPER_BOUND;
            }
            else
                return false;
        }
        private string CheckTextBound(string sCurrent, KeyEventArgs e)
        {

            if (IsValid(sCurrent))
            {
                int iCurrentValue = int.Parse(sCurrent);

                switch (e.Key)
                {
                    case Key.Down:
                        iCurrentValue--;
                        break;
                    case Key.Up:
                        iCurrentValue++;
                        break;
                    default:
                        break;
                }

                switch (iCurrentValue)
                {
                    case < LOWER_BOUND:
                        iCurrentValue = LOWER_BOUND;
                        break;
                    case > UPPER_BOUND:
                        iCurrentValue = UPPER_BOUND;
                        break;
                    default:
                        break;
                }

                sCurrent = iCurrentValue.ToString().Trim();
            }
            return sCurrent;
        }
        private void RefreshPool()
        {
            if (this.IsLoaded)
            {
                if (txtRed.Text.Trim() == "")
                    txtRed.Text = "0".Trim();
                if (txtBlack.Text.Trim() == "")
                    txtBlack.Text = "0".Trim();
                if (txtWhite.Text.Trim() == "")
                    txtWhite.Text = "0".Trim();


                _pool.RedDiceAmount = int.Parse(txtRed.Text);
                _pool.BlackDiceAmount = int.Parse(txtBlack.Text);
                _pool.WhiteDiceAmount = int.Parse(txtWhite.Text);
            }
        }
        #endregion
    }
}
