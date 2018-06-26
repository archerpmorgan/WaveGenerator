using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WaveGenerator;

namespace WaveGeneratorExample
{
    public class Program
    {
        static void Main(string[] args)
        {

            var comps = new WaveConfig[3];
            comps[0] = new WaveConfig(WaveType.Sine, 0.001, 70);
            comps[1] = new WaveConfig(WaveType.Sine, 0.01, 30);
            comps[2] = new WaveConfig(WaveType.Flat, 1, 1)
            {
                VerticalShift = 130
            };

            var g = new WaveGenerator.WaveGenerator(comps);

            while (true)
            {
                var text = new string('-', (int)g.Read());
                Console.WriteLine(text);

                Thread.Sleep(10);
            }
        }
    }
}