using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator
{
    public class LevelClass
    {
        public string Level { get; set; }
        public string Class { get; set; }




        public LevelClass(string level,string _class)
        {
            Level = level;
            Class = _class;


        }


        public LevelClass()
        {

        }

    }
}
