using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab_5
{
    static class Controller 
    {
        public static void SortByConsuption(Carrier obj)
        {
            var sortedUsers = from i in obj.data
                orderby i.consumption
                select i;
            foreach (Vehicle i in sortedUsers)
            {
                Console.WriteLine(i.consumption);
            }
             

        }

        public static void ChoiseBySpeed(int min, int max, Carrier obj)
        {
            Vehicle A = new Vehicle();
            for (int i = 0; i < obj.data.Count; i++)
            {

                A = obj.data.ElementAt(i);
                if (A.speed > min && A.speed < max)
                {
                    Console.WriteLine($"{A.name} у этого транспортного средства скорость от {min} до {max}");
                }
            }

        }
    }
}
