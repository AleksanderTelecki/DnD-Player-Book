using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator.DataBase.DBClasses
{
    public class Player
    {
        public int id { get; set; }
        public int Race_id { get; set; }

        public int SubRace_id { get; set; }



        public string PlayerName { get; set; }

        public string PlayerImage { get; set; }

        public string Experience { get; set; }

        public string Weight { get; set; }

        public string Height { get; set; }

        public string History { get; set; }

        public string WorldView { get; set; }

        public string CharacterTraits { get; set; }

        public string Attachments { get; set; }

        public string Ideals { get; set; }

        public string Weaknesses { get; set; }

        public string Features { get; set; }

        public string Speed { get; set; }

        public string ConditionDescription { get; set; }

        public string MasteryBonus { get; set; }

        public string Initiative { get; set; }




    }
}
