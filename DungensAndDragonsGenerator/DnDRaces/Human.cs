using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator
{
    public class Human
    {

        public string Naming
        {

            get
            {
                return "Человек";
            }
        }





        public List<RacePattern> SubRace_ = new List<RacePattern> { new RacePattern("Человек", new StatusBonus(1, 1, 1, 1, 1, 1, 0, 30, "")) };


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
