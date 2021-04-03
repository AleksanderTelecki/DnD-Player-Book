using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace DungensAndDragonsGenerator
{
    /// <summary>
    /// Interaction logic for PDFReader.xaml
    /// </summary>
    public partial class PDFReader : Window
    {
        public PDFReader()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {

                //string link = null;
                //switch (MainWindow.PDFPageIndex)
                //{
                //    case 1:
                //        {
                //            link = "https://dungeonsanddragons.ru/bookfull/5ed/5e%20Players%20Handbook%20-%20%D0%9A%D0%BD%D0%B8%D0%B3%D0%B0%20%D0%B8%D0%B3%D1%80%D0%BE%D0%BA%D0%B0%20RUS.pdf";
                //        }
                //        break;
                //    case 2:
                //        {
                //            link = "https://dungeonsanddragons.ru/bookfull/5ed/5e%20Dungeon%20Masters%20Guide%20-%20%D0%A0%D1%83%D0%BA%D0%BE%D0%B2%D0%BE%D0%B4%D1%81%D1%82%D0%B2%D0%BE%20%D0%9C%D0%B0%D1%81%D1%82%D0%B5%D1%80%D0%B0%20RUS.pdf";
                //        }
                //        break;
                //    case 3:
                //        {
                //            link = "https://dungeonsanddragons.ru/bookfull/Monster%20Manual%205e%20RUS.pdf";
                //        }
                //        break;
                //    default:
                //        break;
                //}
               // Brows.Address = link;

            }
            catch(Exception r)
            {
                MessageBox.Show(r.Message);
            }
           
        }
    }
}
