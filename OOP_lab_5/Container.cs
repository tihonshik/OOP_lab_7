using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab_5
{
    class Carrier
    {
        public List<Vehicle> data = new List<Vehicle>();
        public static int counter = 0;


        public void Output()
        {
            if (counter == 0)
            {
                CarrierIsEmptyException e = new CarrierIsEmptyException("Error, carrier is empty");
                throw e;
            }
            else
            {
                foreach (object i in data)
                {
                    Console.WriteLine($"Объект {i}");
                }
            }
        }

        public void Remove(Vehicle A)
        {
            data.Remove(A);
        }

        public void ClearCarrier()
        {
            if (counter == 0)
            {
                CarrierIsEmptyException e = new CarrierIsEmptyException("Error, carrier is empty");
                throw e;
            }
            else
            {
                counter = 0;
                data.Clear();
                Console.WriteLine("Carrier очищен");

            }
        }

        public void Push(Vehicle N)
        {
            data.Add(N);
            counter++;
        }
    }
}
