using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator
{
    public static class Initializer
    {



        private static List<Class> _classes = InitializeClasses();
        public static List<Class> Classes { get=> _classes;}

        private static List<Race> _races = InitializeRaces();
        public static List<Race> Races { get => _races; }


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

        public static List<Class> InitializeClasses()
        {
            List<Class> classes = new List<Class>();
            List<string> subclasses;

            DNDEntities entities = new DNDEntities();
            var TClasses= entities.TableClass.Select(p => p).ToList<TableClass>();

            foreach (var itemclass in TClasses)
            {
                subclasses = new List<string>();
                var TSubClass = entities.TableSubClass.Where(p => p.IDClass == itemclass.ID).ToList<TableSubClass>();

                foreach (var itemsubclass in TSubClass)
                {
                    subclasses.Add(itemsubclass.Name);
                }
                MyEnums.Ability ST = MyEnums.Ability.None;
                ST+= int.Parse(itemclass.SAVINGTHROGH);
                classes.Add(new Class(itemclass.Name, new Proficiences(itemclass.PROFICIENCY), ST, subclasses));


            }


            return classes;


        }


   
        public static List<Race> InitializeRaces()
        {
            List<Race> races = new List<Race>();
            List<Race> subraces;
            Dictionary<MyEnums.Ability, string> abilityBonus = new Dictionary<MyEnums.Ability, string>();
            Dictionary<MyEnums.Ability, string> OptAbilityBonus = new Dictionary<MyEnums.Ability, string>();


            DNDEntities entities = new DNDEntities();
            var TRace = entities.TableRace.Select(p => p).ToList<TableRace>();

            foreach (var itemrace in TRace)
            {

                subraces = new List<Race>();
                var subRaces = entities.TableSubRace.Where(p=>p.RaceID==itemrace.ID).ToList<TableSubRace>();

                foreach (var itemsubrace in subRaces)
                {
                    abilityBonus = abilityBonus.InitializeDictionary();
                    OptAbilityBonus = OptAbilityBonus.InitializeDictionary();
                    
                    string[] SubArray = new string[4];
                    itemsubrace.Speed.Split().CopyTo(SubArray, 0);
                    subraces.Add(new Race(itemsubrace.Name, SubArray[0], SubArray[1], SubArray[2], SubArray[3], itemsubrace.AdditionalInfo, itemsubrace.AdditionHitPoints, abilityBonus.ConvertToDictionary(itemsubrace.ABILITYBONUS), null, OptAbilityBonus.ConvertToDictionary(itemsubrace.ABILITYOPTBONUS), itemsubrace.DESCRIPTION));

                }

                abilityBonus = abilityBonus.InitializeDictionary();
                OptAbilityBonus = OptAbilityBonus.InitializeDictionary();

                string[] Array = new string[4];
                itemrace.Speed.Split().CopyTo(Array, 0);
                races.Add(new Race(itemrace.Name, Array[0], Array[1], Array[2], Array[3], itemrace.AdditionalInfo, itemrace.AdditionHitPoints, abilityBonus.ConvertToDictionary(itemrace.ABILITYBONUS),subraces, OptAbilityBonus.ConvertToDictionary(itemrace.ABILITYOPTBONUS), itemrace.DESCRIPTION));

            }

            return races;


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
