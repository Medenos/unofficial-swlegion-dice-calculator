using LIB_SWL_Dice_Calculator.PoolModels;
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
    /// Interaction logic for pgDefensePool.xaml
    /// </summary>
    public partial class pgCombatSimulation : Page
    {
        const int UPPER_BOUND = 99;
        const int LOWER_BOUND = 0;

        AttackPool _AttackPool = new AttackPool();

        public pgCombatSimulation()
        {
            InitializeComponent();
        }


        //private void txtRed_PreviewKeyDown(object sender, KeyEventArgs e)
        //{
        //    txtRed.Text = CheckTextBound(txtRed.Text, e);
        //}
        //private void txtRed_PreviewTextInput(object sender, TextCompositionEventArgs e)
        //{
        //    e.Handled = true;
        //    if (IsValid(e.Text))
        //    {
        //        if (txtRed.Text.Length >= 2)
        //            txtRed.Text = txtRed.Text[1] + e.Text;
        //        else
        //            txtRed.Text += e.Text;
        //    }
        //}
        //private void txtRed_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (txtRed.Text.Length > 1)
        //        if (txtRed.Text.First() == '0')
        //            txtRed.Text = txtRed.Text.Remove(0, 1);
        //    RefreshPool();
        //}


        //private void txtBlack_PreviewKeyDown(object sender, KeyEventArgs e)
        //{
        //    txtBlack.Text = CheckTextBound(txtBlack.Text, e);
        //}
        //private void txtBlack_PreviewTextInput(object sender, TextCompositionEventArgs e)
        //{
        //    e.Handled = true;
        //    if (IsValid(e.Text))
        //    {
        //        if (txtBlack.Text.Length >= 2)
        //            txtBlack.Text = txtBlack.Text[1] + e.Text;
        //        else
        //            txtBlack.Text += e.Text;
        //    }
        //}
        //private void txtBlack_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (txtBlack.Text.Length > 1)
        //        if (txtBlack.Text.First() == '0')
        //            txtBlack.Text = txtBlack.Text.Remove(0, 1);
        //    RefreshPool();
        //}

        //private void txtWhite_PreviewKeyDown(object sender, KeyEventArgs e)
        //{
        //    txtWhite.Text = CheckTextBound(txtWhite.Text, e);
        //}
        //private void txtWhite_PreviewTextInput(object sender, TextCompositionEventArgs e)
        //{
        //    e.Handled = true;
        //    if (IsValid(e.Text))
        //    {
        //        if (txtWhite.Text.Length >= 2)
        //            txtWhite.Text = txtWhite.Text[1] + e.Text;
        //        else
        //            txtWhite.Text += e.Text;
        //    }
        //}
        //private void txtWhite_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (txtWhite.Text.Length > 1)
        //        if (txtWhite.Text.First() == '0')
        //            txtWhite.Text = txtWhite.Text.Remove(0, 1);
        //    RefreshPool();
        //}

        //#region Functions
        //private bool IsValid(string sInput)
        //{
        //    if (sInput != null)
        //    {
        //        int i;
        //        return int.TryParse(sInput, out i) && i >= LOWER_BOUND && i <= UPPER_BOUND;
        //    }
        //    else
        //        return false;
        //}
        //private string CheckTextBound(string sCurrent, KeyEventArgs e)
        //{

        //    if (IsValid(sCurrent))
        //    {
        //        int iCurrentValue = int.Parse(sCurrent);

        //        switch (e.Key)
        //        {
        //            case Key.Down:
        //                iCurrentValue--;
        //                break;
        //            case Key.Up:
        //                iCurrentValue++;
        //                break;
        //            default:
        //                break;
        //        }

        //        switch (iCurrentValue)
        //        {
        //            case < LOWER_BOUND:
        //                iCurrentValue = LOWER_BOUND;
        //                break;
        //            case > UPPER_BOUND:
        //                iCurrentValue = UPPER_BOUND;
        //                break;
        //            default:
        //                break;
        //        }

        //        sCurrent = iCurrentValue.ToString().Trim();
        //    }
        //    return sCurrent;
        //}
        //private void RefreshPool()
        //{
        //    if (this.IsLoaded)
        //    {
        //        if (txtRed.Text.Trim() == "")
        //            txtRed.Text = "0".Trim();
        //        if (txtBlack.Text.Trim() == "")
        //            txtBlack.Text = "0".Trim();
        //        if (txtWhite.Text.Trim() == "")
        //            txtWhite.Text = "0".Trim();

        //        _AttackPool.RedDiceAmount = int.Parse(txtRed.Text);
        //        _AttackPool.BlackDiceAmount = int.Parse(txtBlack.Text);
        //        _AttackPool.WhiteDiceAmount = int.Parse(txtWhite.Text);
        //    }
        //}
        //#endregion
    }
}
