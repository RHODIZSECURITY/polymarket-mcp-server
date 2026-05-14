# RHODIZ NT8 Demo Integration

## Objective

Connect RHODIZ market intelligence into NinjaTrader 8.1 in DEMO mode.

## Included Files

- RHODIZMarketSignal.cs
- RHODIZEventBridge.cs
- RHODIZSignalFilter.cs

## Installation

Copy all .cs files into:

Documents/NinjaTrader 8/bin/Custom/

Then:

1. Open NinjaTrader 8.1
2. Open NinjaScript Editor
3. Compile

## Demo Behavior

Current mode:

- Demo only
- Read-only
- No autonomous execution
- Bullish/Bearish filter only

## Example Integration

var bridge = new RHODIZEventBridge();
var signal = await bridge.GetSignalAsync();

if (signal.Bias == RHODIZBias.Bullish)
{
    // allow longs
}

if (signal.Bias == RHODIZBias.Bearish)
{
    // allow shorts
}
