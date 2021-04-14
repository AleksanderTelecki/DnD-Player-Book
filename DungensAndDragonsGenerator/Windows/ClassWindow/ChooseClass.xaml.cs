using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ChooseClass.xaml
    /// </summary>
    public partial class ChooseClass : Window
    {
        public ChooseClass()
        {
            
            InitializeComponent();
          
        }

        private void AddClass_Click(object sender, RoutedEventArgs e)
        {
            var x = this.DataContext;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = new ClassViewModel(new ObservableCollection<Class>(Initializer.Classes), Combo_SubClass);
            
        }
    }
}
