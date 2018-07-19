using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WaveGenerator;
using System.Diagnostics;

namespace WaveGeneratorExample
{
    public class Program
    {
        static void Main(string[] args)
        {

            var comps = new WaveConfig[1];
            comps[0] = new WaveConfig()
            {
                Amplitude = 10,
                FrequencyInKilohertz = 0.002,
                WaveType = WaveType.Sine,
                Offset = 60
            };

            var g = new WaveGenerator.WaveGenerator(comps);
            var sw = new Stopwatch();
            sw.Start();

            while (true)
            { 
                var text = new string('-',  60 + (int)g.Read());
                Console.WriteLine(sw.Elapsed.ToString() + text);
                Thread.Sleep(10);
            }
        }
    }
}