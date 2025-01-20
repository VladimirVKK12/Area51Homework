using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Area51Homework
{
    internal class Agent
    {
        private Elevator Elevator { get; set; }
        public int Floor { get; set; }
        public int SecurityLevel { get; set; } 

        public Agent(Elevator elevator, int securityLevel, int startFloor)
        {
            Elevator = elevator;
            SecurityLevel = securityLevel;
            Floor = startFloor;
        }

        public void StandardWorkflow(int cycles)
        {
            for (int i = 0;i < cycles; i++)
            {
                Elevator.CallAndEnter(Floor, this);
                int desiredFloor = new Random().Next(0, 4);
                Console.WriteLine($"Agent security level {SecurityLevel} trying to go to floor {desiredFloor}");

                if (Elevator.GoToFloorAndLeave(desiredFloor))
                {
                    Console.WriteLine($"Agent security level {SecurityLevel} reached floor {desiredFloor}");
                    Floor = desiredFloor;
                }
                else
                {
                    Console.WriteLine($"Agent security level {SecurityLevel} denied access to floor {desiredFloor}");
                }
                Console.WriteLine("////////////////////////////");
                Thread.Sleep(3000);
            }
        }
    }
}
