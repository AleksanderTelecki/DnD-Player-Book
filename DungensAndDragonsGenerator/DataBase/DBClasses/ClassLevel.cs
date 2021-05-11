using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator.DataBase.DBClasses
{
    public class ClassLevel
    {
        public int id { get; set; }

        public int class_id { get; set; }

        public int subclass_id { get; set; }

        public int level { get; set; }

        public int player_id { get; set; }

    }
}
