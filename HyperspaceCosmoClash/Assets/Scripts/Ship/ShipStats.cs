using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents the statistics of a ship.
/// </summary>
public class ShipStats : HaroMonoBehaviour
{
    [SerializeField] protected float shipmoveSpeed;
    public float ShipMoveSpeed { get => shipmoveSpeed; }
    [SerializeField] protected int shipDamage;
    public int ShipDamage { get => shipDamage; }

    [SerializeField] protected float shipShootSpeed;
    public float ShipShootSpeed { get => shipShootSpeed; }

    [SerializeField] protected int shipHealth;
    public int ShipHeath { get => shipHealth; }


    /// <summary>
    /// Increases the ship's damage by the specified value.
    /// </summary>
    /// <param name="value">The value to increase the ship's damage by.</param>
    public virtual void IncreaseShipDamage(int value)
    {
        shipDamage += value;
    }
}
