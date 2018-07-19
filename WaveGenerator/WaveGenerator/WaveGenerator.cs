using System;
using System.Collections.Generic;

namespace WaveGenerator
{
    public class WaveGenerator
    {
        private readonly WaveConfig[] _configs;

        private readonly Dictionary<WaveType, Func<long, WaveConfig, double>> _wavefuncmap =
            new Dictionary<WaveType, Func<long, WaveConfig, double>>
            {
                {WaveType.Sine, Sine},
                {WaveType.Flat, Flat},
                {WaveType.Square, Square},
                {WaveType.Sawtooth, Sawtooth},
                {WaveType.Triangle, Triangle}
            };

        public WaveGenerator(WaveConfig[] configs)
        {
            this._configs = configs;
        }

        private static double Sine(long x, WaveConfig wc)
        {
            var b = 2 * Math.PI / (1 / wc.FrequencyInKilohertz);
            return wc.Amplitude * Math.Sin(b * x);
        }

        private static double Square(long x, WaveConfig wc)
        {
            var b = 2 * Math.PI / (1 / wc.FrequencyInKilohertz);
            return wc.Amplitude * Math.Sign(Math.Sin(b * x));
        }

        private static double Flat(long x, WaveConfig wc)
        {
            return wc.Offset;
        }

        private static double Sawtooth(long x, WaveConfig wc)
        {
            return 2 * (wc.Amplitude / wc.Period) * x - wc.Amplitude;
        }

        private static double Triangle(long x, WaveConfig wc)
        {
            return 2 * (2 * wc.Amplitude / wc.Period) * (Math.Abs(x - wc.Period / 2) - wc.Period / 4);
        }


        //returns the sum of each wave in the composition at the time
        //the function was called
        public double Read()
        {
            var milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            double retval = 0;
            foreach (var config in _configs)
            {
                var f = _wavefuncmap[config.WaveType];
                milliseconds = (long) (milliseconds % config.Period);
                retval += f(milliseconds, config);
            }

            return retval;
        }
    }
}