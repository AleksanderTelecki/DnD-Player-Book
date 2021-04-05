using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator
{
    public class Skills
    {

        private Dictionary<MyEnums.Ability, string> _abilityset=new Dictionary<MyEnums.Ability, string>();
        public Dictionary<MyEnums.Ability,string> AbilitySet { get => _abilityset; set => _abilityset = value; }

        private Dictionary<MyEnums.Skills, string> _skillset=new Dictionary<MyEnums.Skills, string>();
        public Dictionary<MyEnums.Skills,string> SkillSet { get=> _skillset; set=>_skillset=value; }


        public Skills()
        {
            _abilityset = _abilityset.InitializeDictionary();

            _skillset = _skillset.InitializeDictionary();

        }

    }
}
