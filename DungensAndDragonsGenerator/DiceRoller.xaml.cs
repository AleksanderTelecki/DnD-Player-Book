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

namespace DungensAndDragonsGenerator
{
    /// <summary>
    /// Interaction logic for DiceRoller.xaml
    /// </summary>
    public partial class DiceRoller : Window
    {

        DiceRollPage rollPage = new DiceRollPage();
        SkillPage skillPage = new SkillPage();
        D20 d20 = new D20();
        RollPercPage rollPercPage = new RollPercPage();

        public DiceRoller()
        {
            InitializeComponent();
        }

        private void RandomDice_Click(object sender, RoutedEventArgs e)
        {


            _Frame.Navigate(rollPage); 




        }

        private void Skill_Click(object sender, RoutedEventArgs e)
        {
            _Frame.Navigate(skillPage);

        }

        private void D20_Click(object sender, RoutedEventArgs e)
        {
            _Frame.Navigate(d20);
        }

        private void Perc_Click(object sender, RoutedEventArgs e)
        {
            _Frame.Navigate(rollPercPage);
        }
    }
}
