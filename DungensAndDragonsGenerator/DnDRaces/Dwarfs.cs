using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator
{
    public class Dwarfs
    {


        public string Naming
        {

            get
            {
                return "Дварф";
            }
        }





        public List<RacePattern> SubRace_ = new List<RacePattern> { new RacePattern("Горный Дварф", new StatusBonus(2, 0, 1, 0, 0, 0, 0, 25, "")),new RacePattern("Холмовой Дварф", new StatusBonus(0, 0, 1, 0, 1, 0, 1, 25, "")) };


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
