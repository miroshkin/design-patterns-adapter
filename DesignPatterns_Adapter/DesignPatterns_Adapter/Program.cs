using System;

namespace DesignPatterns_Adapter
{
    //original source https://metanit.com/sharp/patterns/4.2.php
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Design Patterns - Adapter!");

            Driver driver = new Driver();

            Car car = new Car();
            driver.Travel(car);

            Camel camel = new Camel();
            ITransport camelTransport = new CamelToTransportAdapter(camel);
            driver.Travel(camelTransport);
        }
    }

    class Driver 
    {
        public void Travel(ITransport transport)
        {
            transport.Drive();
        }
    }

    class Camel : IAnimal
    {
        public void Move()
        {
            Console.WriteLine("Camel is moving");
        }
    }

    class Car : ITransport
    {
        public void Drive()
        {
            Console.WriteLine("Car is driving");
        }
    }

    interface ITransport
    {
        void Drive();
    }

    interface IAnimal
    {
        void Move();
    }

    class CamelToTransportAdapter: ITransport
    {
        private Camel _camel;

        public CamelToTransportAdapter(Camel camel)
        {
            _camel = camel;
        }

        public void Drive()
        {
            _camel.Move();
        }
    }

}
