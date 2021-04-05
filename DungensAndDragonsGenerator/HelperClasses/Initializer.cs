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

        public static void InitializeClasses()
        {
          





        }

        public static void InitializeRaces()
        {
            List<Race> Races = new List<Race>();
            



        }

        public static Dictionary<MyEnums.Ability, string> InitializeDictionary(this Dictionary<MyEnums.Ability, string> dictionary)
        {

            foreach (MyEnums.Ability item in Enum.GetValues(typeof(MyEnums.Ability)))
            {
                dictionary.Add(item, "0");

            }

            return dictionary;
            
        }

        public static Dictionary<MyEnums.Skills, string> InitializeDictionary(this Dictionary<MyEnums.Skills, string> dictionary)
        {
            foreach (MyEnums.Skills item in Enum.GetValues(typeof(MyEnums.Skills)))
            {
                dictionary.Add(item, "0");

            }

            return dictionary;

        }






    }
}
