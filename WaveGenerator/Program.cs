using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WaveGenerator
{
    class Program
    {
        static void Main(string[] args)
        {

            // sine compostion looks good

            //WaveConfig[] comps = new WaveConfig[3];
            //comps[0] = new WaveConfig(WaveType.Sine, 0.001, 70);
            //comps[1] = new WaveConfig(WaveType.Sine, 0.01, 30);
            //comps[2] = new WaveConfig(WaveType.Flat, 1, 1);
            //comps[2].VerticalShift = 130;

            //WaveGenerator g = new WaveGenerator(comps);


            // square looks good

            //WaveConfig[] comps = new WaveConfig[2];
            //comps[0] = new WaveConfig(WaveType.Square, 0.001, 70);
            //comps[1] = new WaveConfig(WaveType.Flat, 0.01, 30);
            //comps[1].VerticalShift = 130;
            //WaveGenerator g = new WaveGenerator(comps);


            // sawtooth looks good

            //WaveConfig[] comps = new WaveConfig[2];
            //comps[0] = new WaveConfig(WaveType.Sawtooth, 0.001, 70);
            //comps[1] = new WaveConfig(WaveType.Flat, 0.01, 30);
            //comps[1].VerticalShift = 130;
            //WaveGenerator g = new WaveGenerator(comps);


            WaveConfig[] comps = new WaveConfig[2];
            comps[0] = new WaveConfig(WaveType.Triangle, 0.001, 70);
            comps[1] = new WaveConfig(WaveType.Flat, 0.01, 30);
            comps[1].VerticalShift = 130;
            WaveGenerator g = new WaveGenerator(comps);

            while (true)
            {
                var text = new string('-', (int)g.Read());
                Console.WriteLine(text);

                Thread.Sleep(10);
            }
        }
    }
}