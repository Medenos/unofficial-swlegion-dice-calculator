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
using LIB_SWL_Dice_Calculator.ResultModels;
using WPF_SWL_Dice_Calculator.Models;

namespace WPF_SWL_Dice_Calculator.Views
{
    /// <summary>
    /// Interaction logic for pgAttackPool.xaml
    /// </summary>
    public partial class pgAttackPool : Page
    {
        AttackPool _pool = null;
        MediaPlayer _soundPLayer = new MediaPlayer();
        public OptionModel _opt = new OptionModel();
        bool _isPlaying = false;
        const int UPPER_BOUND = 99;
        const int LOWER_BOUND = 0;
        const string RELATIVE_SOUND_PATH = "pack://siteoforigin:,,,/Audio/DiceSounds/";

        public pgAttackPool()
        {
            InitializeComponent();
            _soundPLayer.MediaEnded += _soundPLayer_MediaEnded;
            _soundPLayer.MediaFailed += _soundPLayer_MediaFailed;
            _pool = new AttackPool();
        }

        private void _soundPLayer_MediaFailed(object sender, ExceptionEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _soundPLayer_MediaEnded(object sender, EventArgs e)
        {
            _isPlaying = false;
            _soundPLayer.Stop();
        }

        private void txtRed_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            txtRed.Text = CheckTextBound(txtRed.Text, e);
        }
        private void txtRed_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = true;
            if (IsValid(e.Text))
            {
                if (txtRed.Text.Length >= 2)
                    txtRed.Text = txtRed.Text[1] + e.Text;
                else
                    txtRed.Text += e.Text;
            }
        }
        private void txtRed_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtRed.Text.Length > 1)
                if (txtRed.Text.First() == '0')
                    txtRed.Text = txtRed.Text.Remove(0, 1);
            RefreshPool();
        }


        private void txtBlack_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            txtBlack.Text = CheckTextBound(txtBlack.Text, e);
        }
        private void txtBlack_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = true;
            if (IsValid(e.Text))
            {
                if (txtBlack.Text.Length >= 2)
                    txtBlack.Text = txtBlack.Text[1] + e.Text;
                else
                    txtBlack.Text += e.Text;
            }
        }
        private void txtBlack_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBlack.Text.Length > 1)
                if (txtBlack.Text.First() == '0')
                    txtBlack.Text = txtBlack.Text.Remove(0, 1);
            RefreshPool();
        }

        private void txtWhite_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            txtWhite.Text = CheckTextBound(txtWhite.Text, e);
        }
        private void txtWhite_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = true;
            if (IsValid(e.Text))
            {
                if (txtWhite.Text.Length >= 2)
                    txtWhite.Text = txtWhite.Text[1] + e.Text;
                else
                    txtWhite.Text += e.Text;
            }
        }
        private void txtWhite_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtWhite.Text.Length > 1)
                if (txtWhite.Text.First() == '0')
                    txtWhite.Text = txtWhite.Text.Remove(0, 1);
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
                if (txtCritValue.Text.Trim() == "")
                    txtCritValue.Text = "0".Trim();

                _pool.RedDiceAmount = int.Parse(txtRed.Text);
                _pool.BlackDiceAmount = int.Parse(txtBlack.Text);
                _pool.WhiteDiceAmount = int.Parse(txtWhite.Text);
                _pool.CriticalAmount = int.Parse(txtCritValue.Text);

                txtAverageAmount.Text = _pool.GetAverage(chkSurge.IsChecked).ToString("0.00 hit(s)");
            }
        }
        #endregion

        private void chkSurge_Click(object sender, RoutedEventArgs e)
        {
            RefreshPool();
        }

        private void btnRoll_Click(object sender, RoutedEventArgs e)
        {
            PlayDiceSound();
            RollPool();
        }

        private void RollPool()
        {
            AttackResult result = (AttackResult)_pool.Roll();

            txtHitAmount.Text = result.Hits.ToString();
            txtCriticalHitAmount.Text = result.Criticals.ToString();
            txtSurgeHitAmount.Text = result.Surges.ToString();
            txtMissAmount.Text = result.Blanks.ToString("0 blank(s)");
        }

        private void PlayDiceSound()
        {
            Uri uriToPlay = null;
            bool bPlay = true;

            if (_pool.TotalDiceAmount == 1)
                uriToPlay = new Uri(RELATIVE_SOUND_PATH + "Attack_one.wav", UriKind.RelativeOrAbsolute);
            else if (_pool.TotalDiceAmount > 1 && _pool.TotalDiceAmount <= 3)
                uriToPlay = new Uri(RELATIVE_SOUND_PATH + "Attack_aLittle.wav", UriKind.RelativeOrAbsolute);
            else if (_pool.TotalDiceAmount > 3 && _pool.TotalDiceAmount <= 6)
                uriToPlay = new Uri(RELATIVE_SOUND_PATH + "Attack_some.wav", UriKind.RelativeOrAbsolute);
            else if (_pool.TotalDiceAmount > 6 && _pool.TotalDiceAmount <= 10)
                uriToPlay = new Uri(RELATIVE_SOUND_PATH + "Attack_aLot.wav", UriKind.RelativeOrAbsolute);
            else if (_pool.TotalDiceAmount > 10)
                uriToPlay = new Uri(RELATIVE_SOUND_PATH + "Attack_all.wav", UriKind.RelativeOrAbsolute);
            else
                bPlay = false;

            if (_opt.Muted != true)
                _soundPLayer.IsMuted = false;
            else
                _soundPLayer.IsMuted = true;


            if (!_isPlaying && bPlay)
            {
                _soundPLayer.Volume = 1;
                _soundPLayer.Open(uriToPlay);
                _soundPLayer.Play();
            }
        }

        private void txtCritValue_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            txtCritValue.Text = CheckTextBound(txtCritValue.Text, e);
        }

        private void txtCritValue_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = true;
            if (IsValid(e.Text))
            {
                if (txtCritValue.Text.Length >= 2)
                    txtCritValue.Text = txtCritValue.Text[1] + e.Text;
                else
                    txtCritValue.Text += e.Text;
            }
        }

        private void txtCritValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtCritValue.Text.Length > 1)
                if (txtCritValue.Text.First() == '0')
                    txtCritValue.Text = txtCritValue.Text.Remove(0, 1);
            if (txtCritValue.Text == "" || txtCritValue.Text == null)
                txtCritValue.Text = "0";

            RefreshPool();
        }
    }
}
