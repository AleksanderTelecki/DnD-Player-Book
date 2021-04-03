using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator
{
    public class DragonBorns
    {


        public string Naming
        {

            get
            {
                return "Драконорожденный";
            }
        }





        public List<RacePattern> SubRace_ = new List<RacePattern> { new RacePattern("Белый(Холод)", new StatusBonus(2, 0, 0, 0, 0, 1, 0, 30, "")), new RacePattern("Бронзовый(Электричество)", new StatusBonus(2, 0, 0, 0, 0, 1, 0, 30, "")), new RacePattern("Зелёный(Яд)", new StatusBonus(2, 0, 0, 0, 0, 1, 0, 30, "")), new RacePattern("Золотой(Огонь)", new StatusBonus(2, 0, 0, 0, 0, 1, 0, 30, "")), new RacePattern("Красный(Огонь)", new StatusBonus(2, 0, 0, 0, 0, 1, 0, 30, "")), new RacePattern("Латунный(Огонь)", new StatusBonus(2, 0, 0, 0, 0, 1, 0, 30, "")), new RacePattern("Медный(Кислота)", new StatusBonus(2, 0, 0, 0, 0, 1, 0, 30, "")), new RacePattern("Серебряный(Холод)", new StatusBonus(2, 0, 0, 0, 0, 1, 0, 30, "")), new RacePattern("Синий(Электричество)", new StatusBonus(2, 0, 0, 0, 0, 1, 0, 30, "")), new RacePattern("Чёрный(Кислота)", new StatusBonus(2, 0, 0, 0, 0, 1, 0, 30, "")) };


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
