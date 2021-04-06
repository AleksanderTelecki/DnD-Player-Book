using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator
{
    [Serializable]
    public static class MyEnums
    {
        [Flags]
        public enum Ability { None = 0, STR = 1, CHA = 2, DEX = 4, CON = 8, INT = 16, WIS = 32 }

        [Flags]
        public enum Skills { None = 0, Animal_Handling = 1, Arcana = 2, Athletics = 4, Deception = 8, History = 16, Insight = 32, Intimidation = 64, Investigation = 128, Medicine = 256, Nature = 512, Perception = 1024, Performance = 2048, Persuasion = 4096, Religion = 8192, Sleight_of_Hand = 16384, Stealth = 32768, Survival = 65536, Acrobatic = 131072 }

        public static bool IsNone(this Skills skills) => skills == 0 ? true : false;

        public static bool IsNone(this Ability ability) => ability == 0 ? true : false;

        public static bool IsContain(this Skills skills, Skills skillstocompare)
        {

            if (!skills.IsNone()&&skillstocompare.IsNone())
            {
                return false;
            }

            return (skills & skillstocompare) == skillstocompare ? true : false;
        }

        public static bool IsContain(this Ability ability, Ability abilitytocompare)
        {

            if (!ability.IsNone() && abilitytocompare.IsNone())
            {
                return false;
            }

            return (ability & abilitytocompare) == abilitytocompare ? true : false;
        }

        public static MyEnums.Ability GetAbilityByName(string s)
        {
            foreach (MyEnums.Ability item in Enum.GetValues(typeof(MyEnums.Ability)))
            {
                if (Enum.GetName(typeof(MyEnums.Ability),item)==s)
                {
                    return item;
                }
            }

            return MyEnums.Ability.None;

        }


     


    }
}
