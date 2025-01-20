using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Area51Homework
{
    internal class Elevator
    {
        private int CurrentFloor { get; set; } = 0;
        private Agent Agent { get; set; }
        private readonly object LockObject = new object();

        public void CallAndEnter(int floor, Agent agent)
        {
            lock (LockObject)
            {
                Console.WriteLine($"Elevator called to floor {floor} by agent level {agent.SecurityLevel}");
                Thread.Sleep(1000);
                CurrentFloor = floor;
                Agent = agent;
                Console.WriteLine($"Agent security level {agent.SecurityLevel} entered the elevator at floor {floor}");
            }
        }

        public bool GoToFloorAndLeave(int floor)
        {
            lock (LockObject)
            {
                Console.WriteLine($"Elevator going to floor {floor}");
                Thread.Sleep(1000);
                CurrentFloor = floor;

                if (CheckSecurity(floor))
                {
                    Console.WriteLine($"Elevator door opened at floor {floor}");
                    Agent = null;
                    return true;
                }
                else
                {
                    Console.WriteLine($"Access denied to floor {floor}");
                    return false;
                }
            }
        }

        private bool CheckSecurity(int floor)
        {
            if (Agent == null) return false;

            if (floor == 0)
                return true;
            else if (floor == 1 && Agent.SecurityLevel >= 1)
                return true;
            else if ((floor == 2 || floor == 3) && Agent.SecurityLevel == 2)
                return true;

            return false;
        }
    }
}
