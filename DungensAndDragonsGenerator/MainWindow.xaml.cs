﻿using Microsoft.Win32;
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
        public MainWindow()
        {
             
            InitializeComponent();
            Initializer.WindowSizeInitialize(this);
           


            TabController.DataContext = CurrentPlayer;
            MyEnums.Skills skills = MyEnums.Skills.Acrobatic;
           
            
            
        }

     
        private void Menu_Save(object sender, RoutedEventArgs e)
        {
            FileManager.Serialize<Player>(CurrentPlayer);
        }

        private void Menu_Open(object sender, RoutedEventArgs e)
        {
            FileManager.Desirialize(typeof(Player));
            
        }
    }
}
