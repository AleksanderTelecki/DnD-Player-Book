using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator
{
    public class Halfings
    {


        public string Naming
        {

            get
            {
                return "Полурослик";
            }
        }





        public List<RacePattern> SubRace_ = new List<RacePattern> { new RacePattern("Коренастый", new StatusBonus(0, 2, 1, 0, 0, 0, 0, 25, "")), new RacePattern("Легконогий", new StatusBonus(0, 2, 0, 0, 0, 1, 0, 25, "")) };


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
