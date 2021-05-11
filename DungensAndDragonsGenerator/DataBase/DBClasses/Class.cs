using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator.DataBase.DBClasses
{
    public class Class
    {

        public int id { get; set; }

        public string Name { get; set; }

        public string Proficiency { get; set; }

        public string SavingThrows { get; set; }

        public string Information { get; set; }
        public string Description { get; set; }

        public List<SubClass> SubClasses {get;set;}


    }
}
