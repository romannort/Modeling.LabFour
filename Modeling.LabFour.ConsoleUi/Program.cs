using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modeling.LabFour.ConsoleUi
{
    class Program
    {
        static void Main(string[] args)
        {

            QueueSystem queueSystem = new QueueSystem();
            StatisticsResults result =  queueSystem.Emulate();

            Console.Out.WriteLine("{0} {1} {2} {3}", "Pipes", "Costs", "Profit", "Total");
            foreach (var data in result.results)
            {
                Int32 total = data.Profit - data.Costs;
                Console.Out.WriteLine("{0: 0.0} {1: 0.0} {2: 0.0} {3: 0.0}", data.NumberOfChannels, data.Costs, data.Profit, total);
            }
        }
    }
}
