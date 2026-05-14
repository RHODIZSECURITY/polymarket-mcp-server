#region Using declarations
using System;
#endregion

namespace NinjaTrader.NinjaScript.RHODIZ
{
    public enum RHODIZBias
    {
        Neutral = 0,
        Bullish = 1,
        Bearish = -1
    }

    public enum RHODIZRiskState
    {
        Block = 0,
        Allow = 1,
        Reduce = 2
    }

    public sealed class RHODIZMarketSignal
    {
        public bool Enabled { get; set; }
        public RHODIZBias Bias { get; set; }
        public RHODIZRiskState RiskState { get; set; }
        public double Confidence { get; set; }
        public string Source { get; set; }
        public string Note { get; set; }
        public DateTime TimestampUtc { get; set; }

        public RHODIZMarketSignal()
        {
            Enabled = false;
            Bias = RHODIZBias.Neutral;
            RiskState = RHODIZRiskState.Block;
            Confidence = 0.0;
            Source = "RHODIZ";
            Note = string.Empty;
            TimestampUtc = DateTime.UtcNow;
        }

        public static RHODIZMarketSignal Neutral(string note)
        {
            return new RHODIZMarketSignal
            {
                Enabled = false,
                Bias = RHODIZBias.Neutral,
                RiskState = RHODIZRiskState.Block,
                Confidence = 0.0,
                Source = "RHODIZ",
                Note = note ?? string.Empty,
                TimestampUtc = DateTime.UtcNow
            };
        }
    }
}
