using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator.DataBase.DBClasses
{
    public class Spell
    {

        public int id { get; set; }

        public int player_id { get; set; }


        public string Name { get; set; }

        public int treeview_type { get; set; }

        public string BaseSkill { get; set; }

        public string Bonus { get; set; }

        public string SaveThrowDifficulty { get; set; }

        public string Distance { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }



    }
}
