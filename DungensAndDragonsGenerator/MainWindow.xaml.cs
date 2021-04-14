using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
using System.Xml.Serialization;


namespace DungensAndDragonsGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        public static Player CurrentPlayer = new Player();
        public static PlayerFile PlayerFile;
        public List<Class> DataGridCollection { get; set; }

        #region ConsoleLib
        [DllImport("Kernel32")]
        public static extern void AllocConsole();

        [DllImport("Kernel32")]
        public static extern void FreeConsole();
        #endregion

        public MainWindow()
        {
             
            InitializeComponent();
            Initializer.WindowSizeInitialize(this);
           


            TabController.DataContext = CurrentPlayer;
           


          




        }

     
        private void Menu_Save(object sender, RoutedEventArgs e)
        {
            PlayerFile = new PlayerFile("Jetsuba", CurrentPlayer);
            //FileManager.JSONSerialize<Player>(CurrentPlayer);
            FileManager.JSONSerialize<PlayerFile>(PlayerFile);
        }

        private void Menu_Open(object sender, RoutedEventArgs e)
        {
            // var x = FileManager.JSONDesirialize(typeof(Player));
            //var y = x;
            var x = FileManager.JSONDesirialize(typeof(PlayerFile));
            var y = x;
        }

        private void DataGrid_PlusLvl(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_MinusLvl(object sender, RoutedEventArgs e)
        {

        }

        private void AddClass_Click(object sender, RoutedEventArgs e)
        {
            ChooseClass chooseClass = new ChooseClass();
            chooseClass.Show();
        }
    }
}
