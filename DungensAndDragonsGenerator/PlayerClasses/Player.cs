using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator
{
    [Serializable]
    public class Player
    {

        public string Name { get; set; }

        public Bitmap PlayerImage { get; set; }

        public string Experience { get; set; }

        public string Weight { get; set; }

        public string Height { get; set; }

        public string History { get; set; }

        public List<Class> Class { get; set; }

        private Race _race = new Race();
        public Race Race { get=>_race; set=>_race=value; }

        public Race SubRace { get; set; }

        public int WorldView { get; set; }

        public string CharacterTraits { get; set; }

        public string Attachments { get; set; }

        public string Ideals { get; set; }

        public string Weaknesses { get; set; }

        public string Features { get; set; }

        public string HitPoints { get; set; }

        public string ArmorClass { get; set; }

        private string _speed;
        public string Speed { get => _speed ?? Race?.Speed; set => _speed = value; }

        public List<Condition> Conditions { get; set; }

        public string ConditionDescription { get; set; }

        public List<Weapon> Weapons { get; set; }

        public List<Spell> Spells { get; set; }

        public List<Equipment> Equipments { get; set; }

        public int MasteryBonus { get; set; }

        public int PassiveWise { get; set; }

        public string Initiative { get; set; }

        private Skills _skills = new Skills();
        public Skills Skills { get=>_skills; set=>_skills=value; }

        public Player ()
        {
           


        }


    }
}
