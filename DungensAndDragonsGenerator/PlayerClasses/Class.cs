using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator
{
    [Serializable]
    public class Class
    {
        public string Name{ get;set;}

        public Proficiences ProficiencyChoise { get; set; }

        public MyEnums.Ability SavingThrow { get; set; }

        public List<string> SubClasses { get; set; }

        public Class(string Name,Proficiences Proficiences,MyEnums.Ability SavingThrow,List<string> SubClasses)
        {
            this.Name = Name;
            this.ProficiencyChoise = Proficiences;
            this.SavingThrow = SavingThrow;
            this.SubClasses = SubClasses;

        }

        public Class()
        {

        }

    }

    public class Proficiences
    {
        public string choose { get; set; }

        public MyEnums.Skills Skills {get; set;}

        public Proficiences(string dbarray)
        {
            string[] sArray = dbarray.Split();

            choose = sArray[0];
            Skills +=int.Parse(sArray[1]);



        }

        public Proficiences()
        {

        }

    }

    


}
