using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day5_Abstract___Project_References
{
    public class AeroScience
    {
        public double AeroDynamics(double airDensity, double velocity, double wingArea, double liftCoefficient)
        {
            return 0.5 * airDensity * velocity * velocity * wingArea * liftCoefficient;
        }
    }
}
