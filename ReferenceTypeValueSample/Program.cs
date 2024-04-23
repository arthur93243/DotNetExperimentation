using System;
using System.Text.Json;

namespace ReferenceTypeValueSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = new Car
            {
                color = "Red",
                type = "Civic",
                weight = 3359d
            };
            
            Console.WriteLine($"Before clone, Car color: {car.color}");

            var mycar = new MyCar();
            //Wrong clone
            /*
            mycar.car = car;
            mycar.car.color = "yellow";
            */

            int cycle = 1;

            DateTime start = DateTime.Now;
            Console.WriteLine($"Now is {start:yyyy/MM/dd HH:mm:ss.fff}");
            for (int i = 0; i < cycle; i++)
            {
                mycar = CloneObject_a(car);
            }
            
            Console.WriteLine($"Now is {DateTime.Now:yyyy/MM/dd HH:mm:ss.fff}");
            Console.WriteLine($"CloneObject_a cost {(DateTime.Now - start).TotalMilliseconds}");
            
            Console.WriteLine("-------------------------------------------------");
            
            start = DateTime.Now;
            Console.WriteLine($"Now is {start:yyyy/MM/dd HH:mm:ss.fff}");
            for (int i = 0; i < cycle; i++)
            {
                mycar = CloneObject_b(car);
            }
            
            Console.WriteLine($"Now is {DateTime.Now:yyyy/MM/dd HH:mm:ss.fff}");
            Console.WriteLine($"CloneObject_b cost {(DateTime.Now - start).TotalMilliseconds}");

            Console.WriteLine($"After clone, Car color: {car.color}.  MyCar color: {mycar.car.color}");
        }

        public static MyCar CloneObject_a(Car src)
        {
            return new MyCar
            {
                car = new Car
                {
                    color = "yellow",
                    type = src.type,
                    weight = src.weight
                }
            };
        }
        
        public static MyCar CloneObject_b(Car src)
        {
            var mycar = new MyCar();
            mycar.car = JsonSerializer.Deserialize<Car>(JsonSerializer.Serialize(src));
            mycar.car.color = "yellow";

            return mycar;
        }
    }

    class Car
    {
        public string color { get; set; }
        public string type { get; set; }
        public double weight { get; set; }
    }
    
    class MyCar
    {
        public Car car { get; set; }
    }

    class TestGen<T>
    {
        public string name { get; set; }
    }
}