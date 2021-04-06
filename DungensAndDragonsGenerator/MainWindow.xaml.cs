using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        public MainWindow()
        {
             
            InitializeComponent();
            Initializer.WindowSizeInitialize(this);
           


            TabController.DataContext = CurrentPlayer;
            var x = Initializer.InitializeRaces();
            var y = x;

            var z = Initializer.InitializeClasses();
            var v = z;
           
            
            
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
    }
}
