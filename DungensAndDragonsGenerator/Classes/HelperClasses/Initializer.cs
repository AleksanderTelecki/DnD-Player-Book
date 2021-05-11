using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator
{
    public static class Initializer
    {



       


        public static void WindowSizeInitialize(MainWindow mainWindow)
        {
            int majorVer = Environment.OSVersion.Version.Major;
            int minorVer = Environment.OSVersion.Version.Minor;

            if (majorVer == 6 && minorVer == 1)
            {
                mainWindow.Height = 750;
                mainWindow.Width = 510;
            }
        }



        public static Dictionary<MyEnums.Ability, string> InitializeDictionary(this Dictionary<MyEnums.Ability, string> dictionary)
        {
            dictionary = new Dictionary<MyEnums.Ability, string>();
            foreach (MyEnums.Ability item in Enum.GetValues(typeof(MyEnums.Ability)))
            {
                dictionary.Add(item, "0");

            }

            return dictionary;
            
        }

        public static Dictionary<MyEnums.Skills, string> InitializeDictionary(this Dictionary<MyEnums.Skills, string> dictionary)
        {
            dictionary = new Dictionary<MyEnums.Skills, string>();
            foreach (MyEnums.Skills item in Enum.GetValues(typeof(MyEnums.Skills)))
            {
                dictionary.Add(item, "0");

            }

            return dictionary;

        }

        public static Dictionary<MyEnums.Ability, string> ConvertToDictionary(this Dictionary<MyEnums.Ability, string> dictionary,string Ability)
        {
            string[] sArray = Ability.Split();
            int i = 0;
            foreach (MyEnums.Ability item in Enum.GetValues(typeof(MyEnums.Ability)))
            {
                dictionary[item] = sArray[i];
                i++;
            }



            return dictionary;

        }

        public static Dictionary<MyEnums.Skills, string> ConvertToDictionary(this Dictionary<MyEnums.Skills, string> dictionary, string Ability)
        {

            string[] sArray = Ability.Split();
            int i = 0;
            foreach (MyEnums.Skills item in Enum.GetValues(typeof(MyEnums.Skills)))
            {
                dictionary[item] = sArray[i];
                i++;

            }

            return dictionary;

        }



    }

     
}
