namespace NinjaTrader.NinjaScript.RHODIZ
{
    public sealed class RHODIZSignalFilter
    {
        public bool AllowLong(RHODIZMarketSignal signal)
        {
            return signal != null && signal.Enabled && signal.Bias == RHODIZBias.Bullish && signal.Confidence >= 60;
        }

        public bool AllowShort(RHODIZMarketSignal signal)
        {
            return signal != null && signal.Enabled && signal.Bias == RHODIZBias.Bearish && signal.Confidence >= 60;
        }
    }
}
