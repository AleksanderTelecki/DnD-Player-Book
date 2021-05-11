using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator.DataBase.DBClasses
{
    public class Race
    {

        public int id { get; set; }

        public string Name { get; set; }

        public string Speed { get; set; }

        public string Information { get; set; }

        public string Description { get; set; }

        public string AbilityBonus { get; set; }

        public string AbilityBonusOpt { get; set; }

        public List<SubRace> SubRaces { get; set; }

    }
}
