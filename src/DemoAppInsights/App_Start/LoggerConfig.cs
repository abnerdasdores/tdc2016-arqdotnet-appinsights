using Serilog;
using System.Configuration;

namespace DemoAppInsights
{
    public class LoggerConfig
    {
        public static void Configure()
        {
            var appInsightsKey = ConfigurationManager.AppSettings["ApplicatioInsightsInstrumentationKey"];
            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Information()
                            .WriteTo
                            .ApplicationInsightsEvents(appInsightsKey)
                            .CreateLogger();
        }
    }
}
