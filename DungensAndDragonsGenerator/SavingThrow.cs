using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator
{
   public  class SavingThrow
    {

        public string Strength { get; set; }
        public string Dexterity { get; set; }
        public string Constitution { get; set; }
        public string Intelligence { get; set; }
        public string Wisdom { get; set; }

        public string Charisma { get; set; }





        public SavingThrow(string strength,string dex,string con,string intel,string wis,string chars)
        {

            Strength =$"+{strength}";
            Dexterity = $"+{dex}";
            Constitution = $"+{con}";
            Intelligence = $"+{intel}";
            Wisdom = $"+{wis}";
            Charisma = $"+{chars}";







        }

        public SavingThrow()
        {

        }

        public SavingThrow(SavingThrow saving)
        {
            Strength = saving.Strength;
            Dexterity = saving.Dexterity;
            Constitution = saving.Constitution;
            Intelligence = saving.Intelligence;
            Wisdom = saving.Wisdom;
            Charisma = saving.Charisma;


        }



    }
}
