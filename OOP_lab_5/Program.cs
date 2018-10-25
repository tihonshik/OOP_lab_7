using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace OOP_lab_5
{
    public class Printer
    {
        public void iAmPrinting(object obj)
        {
            Console.WriteLine($"Это {obj.GetType()}");
        }
    }


    public class Vehicle
    {
        protected bool isStarted;
        public string name;
        public int speed;
        public int consumption;
        public virtual void Move()
        {
            Console.WriteLine("ЧТо та двигается!");
        }
    }

    partial class Car : Vehicle, Engine
    {

        public Car(int consumption, int speed, string name)
        {
            if (consumption < 0)
            {
                NegativeConsuption e = new NegativeConsuption("Ошибка отрицательного рассхода");
                throw e;
            }
            else
            {
                           this.consumption = consumption; 
            }

            if (speed > 300)
            {
                ExcessSpeed e = new ExcessSpeed("Ошибка превышение скорости");
                throw e;
            }
            this.speed = speed;
            this.name = name;
        }

        public bool stopEngine()
        {
            this.isStarted = false;
            return false;
        }
        public override void Move()
        {
            Console.WriteLine("Тачка едет");
        }
        
    }

    class Train : Vehicle, Engine
    {
        public Train(int consumption, int speed, string name)
        {
            this.consumption = consumption;
            this.speed = speed;
            this.name = name;
        }

        public bool startEngine()
        {
            this.isStarted = true;
            return true;
        }

        public bool stopEngine()
        {
            this.isStarted = false;
            return false;
        }
  
        public override void Move()
        {
            Console.WriteLine("Поезд едет");
        }
        
    }

    interface Engine
    {
        bool startEngine();
        bool stopEngine();
    }

    class Express : Vehicle
    {
        public Express(int consumption, int speed, string name)
        {
            this.consumption = consumption;
            this.speed = speed;
            this.name = name;
        }

        public override void Move()
        {
            Console.WriteLine("Экспресс-поезд едет");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Vehicle a = obj as Express;
            if (a as Express == null)
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }


    //lab_6_______________________
    enum MyEnum : int
    {
        car,
        train,
        expres
    }

    struct MyStruct
    {
        public string typeVehicle;
        public int number;

        public MyStruct(string typeVehicle, int number)
        {
            this.typeVehicle = typeVehicle;
            this.number = number;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Type: {typeVehicle} ||  number: {number}");
        }
    }

    public class ExcessSpeed : Exception
    {

        public ExcessSpeed(string message) : base()
        {
        }
    }

    public class NegativeConsuption : Exception
    {
        public NegativeConsuption(string message) : base()
        {

        }
    }

    public class CarrierIsEmptyException : Exception
    {
        public CarrierIsEmptyException(string message) : base()
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Vehicle Train_1 = new Train(50, 120, "super-train");
                Vehicle Train_2 = new Express(115, 260, "super-super-train");
                Vehicle Car_1 = new Car(6, 205, "super-car");

                Printer print = new Printer();

                if (Train_1 is Car)
                    Console.WriteLine("Что-то не так");
                else
                    Console.WriteLine("Train is not a Car");

                print.iAmPrinting(Train_1);

                List<object> numbers = new List<object>() {Train_1, Train_2, Car_1, print};

                foreach (object i in numbers)
                {
                    print.iAmPrinting(i);
                }

                //lab_6
                //struct
                MyStruct veh1 = new MyStruct("car", 1875);
                veh1.DisplayInfo();
                //enum
                MyEnum tr1;
                tr1 = MyEnum.train;
                switch (tr1)
                {
                    case MyEnum.car:
                    {
                        Console.WriteLine("Is a car\n");
                        break;
                    }
                    case MyEnum.train:
                    {
                        Console.WriteLine("Is a train\n");
                        break;
                    }
                    case MyEnum.expres:
                    {
                        Console.WriteLine("Is a expres\n");
                        break;
                    }

                }

                Carrier Carr = new Carrier();
                // Carr.Output();                                        //ошибка е1
                //Vehicle Car_3 = new Car(-6, 205, "super-car");        //ошибка е2
                //Vehicle Car_4 = new Car(6, 310, "super-car");        //ошибка е3
                int a = 0;
                //int sum = 5 / a;                                      //ошибка деления на 0
                string[] str = new string[5];                           //ошибка стандартная
                //str[6] = "anything"; Console.WriteLine("It's OK");

                int? pointer = null;
                Debug.Assert(pointer != null, "Переменная равна-- null");


                Carr.Push(Train_1);
                Carr.Push(Train_2);
                Carr.Push(Car_1);
                Carr.Output();

                Controller.ChoiseBySpeed(90, 140, Carr);
                Controller.SortByConsuption(Carr);



            }
            catch (CarrierIsEmptyException e1)
            {
                Console.WriteLine(e1);
            }
            catch (NegativeConsuption e2)
            {
                Console.WriteLine(e2);
            }
            catch (ExcessSpeed e3)
            {
                Console.WriteLine(e3);
            }
            catch (DivideByZeroException e4)
            {
                Console.WriteLine(e4);
            }
            catch (Exception e5)
            {
                Console.WriteLine(e5);
            }

            finally
            {
                Console.WriteLine("Hiii! ");
            }

        }
    }
}
