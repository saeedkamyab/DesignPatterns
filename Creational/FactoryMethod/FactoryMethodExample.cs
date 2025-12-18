using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{

        // Product Interface
        public interface ITransport
        {
            void Deliver();
        }

        // Concrete Product 1
        public class Truck : ITransport
        {
            public void Deliver()
            {
                Console.WriteLine("Delivering by land in a truck.");
            }
        }

        // Concrete Product 2
        public class Ship : ITransport
        {
            public void Deliver()
            {
                Console.WriteLine("Delivering by sea in a ship.");
            }
        }

        // Creator Abstract Class
        public abstract class Logistics
        {
            public abstract ITransport CreateTransport();

            public void PlanDelivery()
            {
                var transport = CreateTransport();
                transport.Deliver();
            }
        }

        // Concrete Creator 1
        public class RoadLogistics : Logistics
        {
            public override ITransport CreateTransport()
            {
                return new Truck();
            }
        }

        // Concrete Creator 2
        public class SeaLogistics : Logistics
        {
            public override ITransport CreateTransport()
            {
                return new Ship();
            }
        }

        class Program2
        {
            //static void Main(string[] args)
            //{
            //    Logistics roadLogistics = new RoadLogistics();
            //    roadLogistics.PlanDelivery();

            //    Logistics seaLogistics = new SeaLogistics();
            //    seaLogistics.PlanDelivery();
            //}
        }
    }
