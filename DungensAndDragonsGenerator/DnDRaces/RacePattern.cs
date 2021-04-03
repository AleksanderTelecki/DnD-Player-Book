using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator
{
   public class RacePattern
    {

        public string Naming { get; set; }

        public StatusBonus _StateBonus { get; set; }

        public RacePattern(string naming,StatusBonus statusbonus)
        {

            Naming = naming;
            _StateBonus = statusbonus;


        }

        public RacePattern()
        {



        }

    }
}
