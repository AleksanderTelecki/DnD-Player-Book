using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator
{
    public class StringStatusBonus
    {


        public string Strength { get; set; }

        public string Dexterity { get; set; }

        public string Constitution { get; set; }

        public string Intelligence { get; set; }

        public string Wisdom { get; set; }

        public string Charisma { get; set; }

        public string Hits { get; set; }

        public string Speed { get; set; }

        public string Info { get; set; }

        public StringStatusBonus(StatusBonus status)
        {


            Strength = $"+{status.Strength}";
            Dexterity = $"+{status.Dexterity}";
            Constitution = $"+{status.Constitution}";
            Intelligence = $"+{status.Intelligence}";
            Wisdom = $"+{status.Wisdom}";
            Charisma = $"+{status.Charisma}";
            Hits = $"+{status.Hits}";
            Speed = $"+{status.Speed}";
            Info = status.Info;



        }

        public StringStatusBonus(StatusBonus status,int variable)
        {

            if (variable==1)
            {


                Strength = $"+{status.Strength}";
                Dexterity = $"+{status.Dexterity}";
                Constitution = $"+{status.Constitution}";
                Intelligence = $"+{status.Intelligence}";
                Wisdom = $"+{status.Wisdom}";
                Charisma = $"+{status.Charisma}";
                Hits = $"+{status.Hits}";
                Speed = $"+{status.Speed}";
                Info = status.Info;
            }
            else
            {
                Strength = $"+{status.Strength}";
                Dexterity = $"+{status.Dexterity}";
                Constitution = $"+{status.Constitution}";
                Intelligence = $"+{status.Intelligence}";
                Wisdom = $"+{status.Wisdom}";
                Charisma = $"+{status.Charisma}";
                Hits = $"+{status.Hits}";
                Speed = $"+{status.Speed}";
                Info = status.Info;
            }



        }




    }
}
