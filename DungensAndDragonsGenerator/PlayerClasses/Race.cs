using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator
{
    public class Race
    {

        public string Name { get; set; }

        public List<AbilityBonus> AbilityBonus { get; set; }

        public List<Race> Subrace { get; set; }

        public string Speed { get; set; }

        public AbilityOptional AbilityOptional { get; set; }

        public string AdditionalInfo { get; set; }

        public string AdditionHitPoint { get; set; }

    }

    public class AbilityBonus
    {
        

        public MyEnums.Ability Ability { get; set; }

        public int Bonus { get; set; }



    }

    public class AbilityOptional
    {
        public int choose { get; set; }

        public MyEnums.Skills Skills { get; set; }

    }



}
