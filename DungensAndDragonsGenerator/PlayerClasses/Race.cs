using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator
{
    [Serializable]
    public class Race
    {

        public string Name { get; set; }

        private Dictionary<MyEnums.Ability, string> _abilityBonus = new Dictionary<MyEnums.Ability, string>();
        public Dictionary<MyEnums.Ability, string> AbilityBonus { get => _abilityBonus; set => _abilityBonus = value; }

        private List<Race> _subrace = new List<Race>();
        public List<Race> Subrace { get => _subrace; set => _subrace = value; }

        public string Speed { get; set; }

        private Dictionary<MyEnums.Ability, string> _abilityOptBonus = new Dictionary<MyEnums.Ability, string>();
        public Dictionary<MyEnums.Ability, string> AbilityOptional { get => _abilityOptBonus; set => _abilityOptBonus = value; }

        public string AdditionalInfo { get; set; }

        public string AdditionHitPoints { get; set; }

        public string Description { get; set; }

        public Race(string Name, string Speed, string AdditionalInfo, string AdditionalHitPoints, Dictionary<MyEnums.Ability, string> AbilityBonus, List<Race> Subraces, Dictionary<MyEnums.Ability, string> abilityOptional,string Description)
        {

            this.Name = Name;
            this.Speed = Speed;
            this.Subrace = Subraces;
            this.AbilityBonus = AbilityBonus;
            this.AdditionalInfo = AdditionalInfo;
            this.AdditionHitPoints = AdditionalHitPoints;
            this.AbilityOptional = abilityOptional;
            this.Description = Description;
            
            



        }

        public Race()
        {



        }


    

}

    public class AbilityBonus
    {
        

        public MyEnums.Ability Ability { get; set; }

        public int Bonus { get; set; }



    }

  



}
