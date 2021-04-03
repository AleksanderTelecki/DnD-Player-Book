using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator
{
    public class Tiflings
    {

        public string Naming
        {

            get
            {
                return "Тифлинг";
            }
        }





        public List<RacePattern> SubRace_ = new List<RacePattern> { new RacePattern("Тифлинг", new StatusBonus(0, 0, 0, 1, 0, 2, 0, 30, "")) };


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
