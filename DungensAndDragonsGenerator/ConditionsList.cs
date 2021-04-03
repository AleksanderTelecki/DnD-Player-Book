using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator
{
   public class ConditionsList
    {

        public string Time { get; set; }

        public string Effect { get; set; }



        public ConditionsList(string time,string effect)
        {

            Time = time;
            Effect = effect;


        }

        public ConditionsList()
        {

        }



    }
}
