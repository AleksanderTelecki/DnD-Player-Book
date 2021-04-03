using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator
{
    public class Chara
    {

        public string MasteryBonus { get; set; }
       
        public string PassiveWise { get; set; }





        Skills skills = new Skills();
       public Skills _Skills
        {
            get
            {
                return skills;
            }


            set
            {
                skills = value;
            }
        }



        Abillities abillities = new Abillities();
        public  Abillities _Abillities
        {
            get
            {

                return abillities;
            }


            set
            {
                abillities = value;
            }
        }


        SavingThrow savingThrow = new SavingThrow();
        public SavingThrow _SavingThrow
        {
            get
            {
                return savingThrow;
            }


            set
            {
                savingThrow = value;
            }
        }





        public Chara(Chara chara)
        {

            _Abillities = chara._Abillities;

            

        }



        public Chara()
        {

        }


    }
}
