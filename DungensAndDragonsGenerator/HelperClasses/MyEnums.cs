using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator
{
    public static class MyEnums
    {
        [Flags]
        public enum Ability { STR = 0, CHA = 1, DEX = 2, CON = 4, INT = 8, WIS = 16 }

        [Flags]
        public enum Skills { Acrobatics = 0, Animal_Handling = 1, Arcana = 2, Athletics = 4, Deception = 8, History = 16, Insight = 32, Intimidation = 64, Investigation = 128, Medicine = 256, Nature = 512, Perception = 1024, Performance = 2048, Persuasion = 4096, Religion = 8192, Sleight_of_Hand = 16384, Stealth = 32768, Survival = 65536 }



    }
}
