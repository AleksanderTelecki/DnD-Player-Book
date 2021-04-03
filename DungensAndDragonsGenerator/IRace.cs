using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator
{
    interface IRace
    {


         string  Naming { get;  }

         string StateBonus { get;  }

        List<RacePattern> Subrace { get;  } 







    }
}
