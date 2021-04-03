using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator
{
    public class StatusBonus
    {

        public int Strength { get; set; }

        public int Dexterity { get; set; }

        public int Constitution { get; set; }

        public int Intelligence { get; set; }

        public int Wisdom { get; set; }

        public int Charisma { get; set; }

        public int Hits { get; set; }

        public int Speed { get; set; }


        public string Info { get; set; }

       


        public StatusBonus(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int hits,int speed,string info)
        {
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
            Hits = hits;
            Speed = speed;
            Info = info;



        }

        public StatusBonus()
        {



        }


       


    }
}
