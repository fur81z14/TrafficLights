using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Semaphore
{
    class Program
    {
        static void Main(string[] args)
        {
            int timeGap = 5; // this value determines the time gap in seconds of scanning of the states...
            TrafficLights trafficLights = new TrafficLights(300, 30); // Creating an instance with predefined values
            Console.WriteLine("Time\t\tTL N\tTL W\tTL S\tTL E"); // Output of table header
            for (DateTime curSec = new DateTime(1,1, 1, 9, 0, 0); //for cycle from 09:00:00 until 09:30:00 with step of timeGap seconds
                curSec <= new DateTime(1, 1, 1, 9, 30, 0); 
                curSec = curSec.AddSeconds(timeGap))
            {
                Console.WriteLine(curSec.ToString("HH:mm:ss") + "\t" + trafficLights.CurrentStates()); // output of current state
                for (int i = 0; i < timeGap; i++) // move forward for timeGap seconds
                    trafficLights.MoveOneSecond(); 
            }
            Console.ReadLine();
        }
    }
}
