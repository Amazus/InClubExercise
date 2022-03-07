using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedBoolean
{
    public readonly float odds;

    public WeightedBoolean(float odds)
    {
        this.odds = Mathf.Clamp01(odds);
    }

    public static WeightedBoolean NOT(WeightedBoolean a) => new WeightedBoolean(1 - a.odds);

    public static WeightedBoolean OR(params WeightedBoolean[] values)
    {
        float odds = 0;
        foreach (var v in values) odds = Mathf.Max(odds, v.odds);
        return new WeightedBoolean(odds);
    }

    public static implicit operator bool(WeightedBoolean m) => m.odds > 0.5;
    public static implicit operator WeightedBoolean(bool v) => new WeightedBoolean(v ? 1 : 0);
}

public static class CoolStuff
{
    public static bool WOW(WeightedBoolean oddsOfDying, WeightedBoolean oddsOfMarriage)
    {
        return WeightedBoolean.NOT(WeightedBoolean.OR(oddsOfDying,oddsOfMarriage));
    }
}
