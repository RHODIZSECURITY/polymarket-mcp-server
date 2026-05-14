#region Using declarations
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
#endregion

namespace NinjaTrader.NinjaScript.RHODIZ
{
    public sealed class RHODIZEventBridge
    {
        private readonly HttpClient client;

        public string Endpoint { get; set; }
        public bool DemoMode { get; set; }

        public RHODIZEventBridge()
        {
            client = new HttpClient();
            Endpoint = "http://127.0.0.1:8080";
            DemoMode = true;
        }

        public async Task<RHODIZMarketSignal> GetSignalAsync()
        {
            try
            {
                if (DemoMode)
                {
                    return new RHODIZMarketSignal
                    {
                        Enabled = true,
                        Bias = RHODIZBias.Bullish,
                        RiskState = RHODIZRiskState.Allow,
                        Confidence = 71.0,
                        Source = "RHODIZ-DEMO",
                        Note = "Demo market intelligence feed active.",
                        TimestampUtc = DateTime.UtcNow
                    };
                }

                var response = await client.GetAsync(Endpoint + "/health");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(content);

                return new RHODIZMarketSignal
                {
                    Enabled = true,
                    Bias = RHODIZBias.Neutral,
                    RiskState = RHODIZRiskState.Allow,
                    Confidence = 50,
                    Source = "RHODIZ-LIVE",
                    Note = json.ToString(),
                    TimestampUtc = DateTime.UtcNow
                };
            }
            catch (Exception ex)
            {
                return RHODIZMarketSignal.Neutral(ex.Message);
            }
        }
    }
}
