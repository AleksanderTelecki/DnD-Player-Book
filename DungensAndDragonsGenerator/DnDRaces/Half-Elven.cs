using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator
{
    public class Half_Elven
    {


        public string Naming
        { 
            get
            {
                return "Полу-Эльф";
            }
        }

        public List<RacePattern> SubRace_ = new List<RacePattern> { new RacePattern("Полу-Эльф",new StatusBonus(0,0,0,0,0,2,0,30, "Значения двух других\nхарактеристик на ваш\nвыбор увеличиваются\nна 1."))};


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
