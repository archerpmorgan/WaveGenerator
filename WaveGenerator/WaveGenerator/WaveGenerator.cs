using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveGenerator
{

    public enum WaveType
    {
        Flat,
        Sine,
        Sawtooth,
        Square,
        Triangle
    }


    public class WaveConfig
    {
        public WaveConfig()
        {
            // initialize to dummy values
            frequency = 1;
            period = 1;
            amplitude = 1;
            wt = WaveType.Flat;
            this.verticalShift = 1;
        }

        public WaveConfig(WaveType wt, double frequency, double amplitude)
        {
            this.frequency = frequency;
            this.period = 1 / frequency;
            this.amplitude = amplitude;
            this.wt = wt;
            this.verticalShift = 0;
        }
        private double frequency; // in cycles per milisecond
        private double period; // in miliseconds
        private double amplitude;
        private WaveType wt;
        private double verticalShift; // must be set individually

        public double Frequency { get => frequency; set => frequency = value; }
        public double Period { get => period; set => period = value; }
        public double Amplitude { get => amplitude; set => amplitude = value; }
        public WaveType WaveType { get => wt; set => wt = value; }
        public double VerticalShift {get => verticalShift; set => verticalShift = value;}

    }


    class WaveGenerator
    {

        private WaveConfig[] comps;

        private Dictionary<WaveType, Func<long, WaveConfig, double>> wavefuncmap = new Dictionary<WaveType, Func<long, WaveConfig, double>>
        {
            { WaveType.Sine, Sine},
            { WaveType.Flat, Flat},
            { WaveType.Square, Square},
            { WaveType.Sawtooth, Sawtooth},
            { WaveType.Triangle, Triangle},
        };

        private static double Sine(long x, WaveConfig wc)
        {
            double b = (2 * Math.PI) / (1 / wc.Frequency);
            return wc.Amplitude * Math.Sin(b * x);
        }

        private static double Square(long x, WaveConfig wc)
        {
            double b = (2 * Math.PI) / (1 / wc.Frequency);
            return wc.Amplitude * Math.Sign(Math.Sin(b * x));
        }

        private static double Flat(long x, WaveConfig wc)
        {
            return wc.VerticalShift;
        }

        private static double Sawtooth(long x, WaveConfig wc)
        {
            return 2*(wc.Amplitude/wc.Period) * x - wc.Amplitude;
        }

        private static double Triangle(long x, WaveConfig wc)
        {
            return 2*((2*wc.Amplitude)/wc.Period) * ((Math.Abs(x - (wc.Period / 2)) - (wc.Period/4)));
        }

        public WaveGenerator(WaveConfig[] comps)
        {
            this.comps = comps;
        }


        //returns the sum of each wave in the composition at the time
        //the function was called
        public double Read()
        {
            long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            double retval = 0;
            for (int i = 0; i < comps.Length; i++){
                var f =  wavefuncmap[comps[i].WaveType];
                milliseconds = (long) (milliseconds % comps[i].Period);
                retval += f(milliseconds, comps[i]);
            }

            return retval;
        }

    }
}
