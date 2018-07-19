namespace WaveGenerator
{
    public class WaveConfig
    {
        private double frequency;

        public WaveConfig()
        {
            // initialize to dummy values
            FrequencyInKilohertz = 1;
            Period = 1;
            Amplitude = 1;
            WaveType = WaveType.Flat;
            Offset = 1;
        }

        public double FrequencyInKilohertz { get { return frequency; } set { frequency = value; Period = 1 / value; } }

        public double Period { get; private set; }

        public double Amplitude { get; set; }

        public WaveType WaveType { get; set; }

        public double Offset { get; set; }
    }
}