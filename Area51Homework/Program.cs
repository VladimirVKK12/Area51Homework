using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Area51Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of cycles for each agent: ");
            int cycles = int.Parse(Console.ReadLine());

            Elevator elevator = new Elevator();

            Agent agent1 = new Agent(elevator, 0, 0);
            Agent agent2 = new Agent(elevator, 1, 1);
            Agent agent3 = new Agent(elevator, 2, 2);

            Thread agent1Thread = new Thread(() => agent1.StandardWorkflow(cycles));
            Thread agent2Thread = new Thread(() => agent2.StandardWorkflow(cycles));
            Thread agent3Thread = new Thread(() => agent3.StandardWorkflow(cycles));

            agent1Thread.Start();
            agent2Thread.Start();
            agent3Thread.Start();

            agent1Thread.Join();
            agent2Thread.Join();
            agent3Thread.Join();

            Console.ReadKey(true);
        }
    }
}
