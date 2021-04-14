using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DungensAndDragonsGenerator
{
    public class ClassViewModel
    {

        private ComboBox SubClassControll;
        private Class selectedclass = new Class();
        public ObservableCollection<Class> Classes { get; set; }

        public Class SelectedClass
        {
            get { return selectedclass; }
            set
            {
                if (value!=null)
                {


                    selectedclass = value;
                    SubClasses = new ObservableCollection<string>(value.SubClasses);
                    SubClassControll.ItemsSource = SubClasses;
                    SubClassControll.SelectedItem = SubClasses[0];
                    SelectedSubClass = SubClasses[0];
                }
            }
        }

        private string selectedsubclass { get; set; }
        public ObservableCollection<String> SubClasses { get; set; }
        public string SelectedSubClass { get => selectedsubclass; set => selectedsubclass = value; }

        public ClassViewModel(ObservableCollection<Class> classes,ComboBox combo)
        {
            SubClassControll = combo;
            SelectedClass = classes[0] ?? new Class();
            Classes = classes;
         
          


        }

    }
}
