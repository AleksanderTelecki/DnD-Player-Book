using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator
{
    [Serializable]
    public class Player
    {


        PersonaBlock personaBlock = new PersonaBlock();
        public PersonaBlock Person
        {
            get
            {
                return personaBlock;
            }

            set
            {

                personaBlock = value;

            }
        }

        Chara chara = new Chara();
        public Chara Charakter
        {
            get
            {
                return chara;
            }

            set
            {
                chara = value;
            }


        }


        ConstituClass constituClass = new ConstituClass();

        public ConstituClass Constitutiun
        {
            get
            {
                return constituClass;
            }


            set
            {
                constituClass = value;
            }
        }


        public List<MagicDamage> MagicDamegeList { get; set; }

        public List<WeaponDamage> WeaponDamageList { get; set; }


        public List<LootBag> LootBagList { get; set; }

        public List<ConditionsList> ConditionList { get; set; }

        public string Osobinosti { get; set; }

        public Player()
        {


        }



    }
}
