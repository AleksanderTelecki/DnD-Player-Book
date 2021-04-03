using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator
{
    public class Class
    {
        public string Name{ get;set;}

        public Proficiences ProficiencyChoise { get; set; }

        public MyEnums.Ability SavingThrowth { get; set; }

        public int Level { get; set; }


    }

    public class Proficiences
    {
        public int choose { get; set; }

        public MyEnums.Skills Skills {get; set;}

    }


}
