using System.Collections.Generic;

namespace DungensAndDragonsGenerator
{
    public class ElvenRace 
    {
        public  string Naming
        {

            get
            {
                return "Эльф";
            }
        }




        
       public  List<RacePattern> SubRace_ = new List<RacePattern> {new RacePattern("Высший Эльф",new StatusBonus(0,2,0,1,0,0,0,30,"")),new RacePattern("Темный Эльф",new StatusBonus(0,2,0,0,0,1,0,30,"")),new RacePattern("Лесной Эльф",new StatusBonus(0,2,0,0,1,0,0,35,"")) };
        

        public List<RacePattern> Subrace
        {
            get
            {
               


                return SubRace_;


            }
        }

        public List<string> GetListSubRaceStringNames()
        {
            List<string> SubNaming = new List<string>();
            foreach (var item in Subrace)
            {
                SubNaming.Add(item.Naming);
            }



            return SubNaming;
        }
       


    }
}