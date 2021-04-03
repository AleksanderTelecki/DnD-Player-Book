using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungensAndDragonsGenerator
{
    public class RollDice
    {









        public static string Roll(int dice,int count)
        {
            Random rand = new Random();
            string result;
            count--;
            result = dice==10? $"{rand.Next(0, dice)}":$"{rand.Next(1,dice+1)}";

            if (count>0)
            {


                for (int i = 0; i < count; i++)
                {

                    result += dice == 10 ? $"-{rand.Next(0, dice)}" : $"-{rand.Next(1, dice + 1)}";

                }

            }


            return result;

        }



        public static string RollSkills()
        {
            int[] Randskils = new int[6];
            
            Random rand = new Random();
            for (int i = 0; i <Randskils.Length; i++)
            {
                
                    int[] Roll = new int[4];
                    Roll[0]= rand.Next(1, 7);
                    Roll[1] = rand.Next(1, 7);
                    Roll[2] = rand.Next(1, 7);
                    Roll[3] = rand.Next(1, 7);

                int sum = Roll[0] + Roll[1] + Roll[2] + Roll[3] - Roll.Min();

                Randskils[i] = sum;
                    


            }

            return$"{Randskils[0]}-{Randskils[1]}-{Randskils[2]}-{Randskils[3]}-{Randskils[4]}-{Randskils[5]}";


        }

        public static string RollD20()
        {
            Random rand = new Random();
            return $"{rand.Next(1,21)}";

        }

        public static string RollPerc()
        {
            Random rand = new Random();
            return $"{rand.Next(1, 101)}%";

        }





    }
}
