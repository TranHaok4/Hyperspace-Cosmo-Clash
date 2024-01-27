using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    public virtual void IncreaseShipDamage(int value)
    {
        shipDamage += value;
    }
}
