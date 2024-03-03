using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for sending damage to a DamageReceiver.
/// </summary>
public abstract class DamageSender : HaroMonoBehaviour
{
    [SerializeField] protected int damage = 1;

    /// <summary>
    /// Sends damage to the specified object.
    /// </summary>
    /// <param name="obj">The transform of the object to send damage to.</param>
    public virtual void SendDamage(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        this.SendDamage(damageReceiver);
    }

    /// <summary>
    /// Sends damage to the specified DamageReceiver.
    /// </summary>
    /// <param name="damageReceiver">The DamageReceiver to send damage to.</param>
    public virtual void SendDamage(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
    }
    
    /// <summary>
    /// Changes the damage value.
    /// </summary>
    /// <param name="value">The new damage value.</param>
    public virtual void ChangeDamage(int value)
    {
        damage = value;
    }
}
