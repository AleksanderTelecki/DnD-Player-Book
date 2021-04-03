using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator
{
    public class DnDRaces
    {
        public static ElvenRace Elven
        {
            get
            {
                ElvenRace Elven = new ElvenRace();




                return Elven;
            }
        }


        public static Half_Elven HalfElven
        {
            get
            {
                Half_Elven HalfElven = new Half_Elven();




                return HalfElven;
            }
        }

        public static HalfOrk Half_Ork
        {




            get
            {
                HalfOrk halfOrk = new HalfOrk();


                return halfOrk;
            }
        }

        public static Human Human_
        {


            get
            {
                Human human = new Human();
                return human;
            }


        }

        public static DragonBorns DragonBorn
        {

            get
            {
                DragonBorns dragonBorns = new DragonBorns();
                return dragonBorns;
            }
        }

        public static Tiflings Tifling
        {

            get
            {
                Tiflings tiflings = new Tiflings();
                return tiflings;
            }
        }


        public static Gnoms Gnom
        {


            get
            {
                Gnoms gnoms = new Gnoms();
                return gnoms;
            }

        }

        public static Halfings Halfin
        {

            get
            {
                Halfings halfings = new Halfings();
                return halfings;
            }

        }


        public static Dwarfs Dwarf
        {



            get
            {

                Dwarfs dwarfs = new Dwarfs();
                return dwarfs;

            }

        }

        public static List<string> DNDGetRace(int number)
        {
            switch (number)
            {
                case 0:
                    {
                        return Elven.GetListSubRaceStringNames();
                    }
                case 1:
                    {
                        return HalfElven.GetListSubRaceStringNames();
                    }
                case 2:
                    {

                        return Half_Ork.GetListSubRaceStringNames();

                    }
                case 3:
                    {
                        return Human_.GetListSubRaceStringNames();
                    }
                case 4:
                    {
                        return DragonBorn.GetListSubRaceStringNames();
                    }
                case 5:
                    {
                        return Tifling.GetListSubRaceStringNames();
                    }
                case 6:
                    {
                        return Gnom.GetListSubRaceStringNames();
                    }
                case 7:
                    {
                        return Halfin.GetListSubRaceStringNames();
                    }
                case 8:
                    {
                        return Dwarf.GetListSubRaceStringNames();
                    }

                default:
                    return null;
                    
            }





        }


        public static StatusBonus DNDGetStatus(int numberace,int subrace)
        {

         

            if (numberace == 0)
            {


               
                return Elven.Subrace[subrace]._StateBonus;
            }
            else if (numberace==1)
            {

               

                return HalfElven.Subrace[0]._StateBonus;

            }
            else if(numberace==2)
            {
                return Half_Ork.Subrace[0]._StateBonus;
            }
            else if(numberace==3)
            {
                return Human_.Subrace[0]._StateBonus;
            }
            else if (numberace==4)
            {
                return DragonBorn.Subrace[subrace]._StateBonus;
            }
            else if (numberace==5)
            {
                return Tifling.Subrace[0]._StateBonus;
            }
            else if (numberace==6)
            {
                return Gnom.Subrace[subrace]._StateBonus;
            }
            else if (numberace==7)
            {
                return Halfin.Subrace[subrace]._StateBonus;
            }
            else if (numberace==8)
            {
                return Dwarf.Subrace[subrace]._StateBonus;
            }
            else
            {
                return null;
            }



        }
         

    }
}
