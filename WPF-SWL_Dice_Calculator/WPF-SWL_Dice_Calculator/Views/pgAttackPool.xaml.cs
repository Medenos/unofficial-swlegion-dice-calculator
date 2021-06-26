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

        public pgAttackPool()
        {
            InitializeComponent();
            _pool = new AttackPool();
            _pool.DiceAddedOrRemoved += _pool_DiceAddedOrRemoved;
        }

        private void _pool_DiceAddedOrRemoved(object sender, List<Die> e)
        {
            throw new NotImplementedException();
        }

        private void txtRed_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Down:
                    _pool.RemoveDie(new AttackRed());
                    break;
                case Key.Up:
                    _pool.AddDie(new AttackRed());
                    break;
                default:
                    break;
            }
        }
    }
}
