using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator.DataBase.DBClasses
{
    public class Ability
    {
        public int id { get; set; }

        public int player_id { get; set; }

        public string STR { get; set; }

        public string CHA { get; set; }

        public string DEX { get; set; }

        public string CON { get; set; }

        public string INT { get; set; }

        public string WIS { get; set; }


    }
}
