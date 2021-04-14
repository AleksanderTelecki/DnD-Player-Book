using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator
{
    public class PlayerFile
    {


        public string FileName { get; set; }

        private DateTime date = new DateTime();
        public DateTime Time { get => date; set => date = value;}

        private Player player = new Player();
        public Player Player { get=>player; set=>player=value; }

        public PlayerFile(string FileName,Player Player)
        {
            this.FileName = FileName;
            this.Player = Player;
            this.Time = DateTime.Now;
        }



    }
}
