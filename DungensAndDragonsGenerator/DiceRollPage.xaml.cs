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

namespace DungensAndDragonsGenerator
{
    /// <summary>
    /// Interaction logic for DiceRollPage.xaml
    /// </summary>
    public partial class DiceRollPage : Page
    {
        public DiceRollPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {








            if (ComboDice.SelectedIndex!=-1&&ComboCount.SelectedIndex!=-1)
            {
                _TextRand.Text = RollDice.Roll(IndexSearch(ComboDice.SelectedIndex), int.Parse(ComboCount.Text));
            }



        }




        public int IndexSearch(int i)
        {
           
            switch (i)
            {
                case 0:
                    return 4;
                case 1:
                    return 6;
                case 2:
                    return 8;
                case 3:
                    return 10;
                case 4:
                    return 12;
                case 5:
                    return 20;

                default:
                    return 0;
                    
            }


        }




    }
}
