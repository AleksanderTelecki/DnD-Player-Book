using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator.DataBase.DBClasses
{
    public class Equipment
    {
        public int id { get; set; }

        public int player_id { get; set; }

        public string Description { get; set; }

        public string Count { get; set; }

        public string Image { get; set; }



    }
}
