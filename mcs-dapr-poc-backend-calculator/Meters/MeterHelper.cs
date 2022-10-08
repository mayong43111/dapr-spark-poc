using System.Diagnostics.Metrics;
using System.Reflection;

namespace MCS.Dapr.POC.Backend.Calculator.Meters
{
    public static class MeterHelper
    {
        public static readonly string MeterName = Assembly.GetCallingAssembly().GetName().Name ?? "Calculator.Meters";

        private static readonly Meter RequestMeter = new(MeterName, "1.0");

        public static readonly Counter<long> ComputedResult = RequestMeter.CreateCounter<long>($"MCS_{nameof(ComputedResult)}");
    }
}
