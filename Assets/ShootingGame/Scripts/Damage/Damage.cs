using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public readonly struct Damage : IEquatable<Damage>
{
    public int damageValue { get; }

    public Damage(int value)
    {
        damageValue = value;
    }

    public bool Equals(Damage other)
    {
        return damageValue == other.damageValue;
    }

    public override bool Equals(object obj)
    {
        return obj is Damage other && Equals(other);
    }
}
