namespace WaveGenerator
{
    public class WaveConfig
    {
        public WaveConfig()
        {
            // initialize to dummy values
            Frequency = 1;
            Period = 1;
            Amplitude = 1;
            WaveType = WaveType.Flat;
            VerticalShift = 1;
        }

        public WaveConfig(WaveType wt, double frequency, double amplitude)
        {
            Frequency = frequency;
            Period = 1 / frequency;
            Amplitude = amplitude;
            WaveType = wt;
            VerticalShift = 0;
        }

        public double Frequency { get; set; }

        public double Period { get; set; }

        public double Amplitude { get; set; }

        public WaveType WaveType { get; set; }

        public double VerticalShift { get; set; }
    }
}