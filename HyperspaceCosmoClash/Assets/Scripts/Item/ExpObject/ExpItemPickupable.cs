using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents an item that can be picked up and grants experience points when collected.
/// </summary>
public class ExpItemPickupable : ItemPickupable
{
    [SerializeField] protected ExpItemProfileSO expItemProfile;

    /// <summary>
    /// Called when the item is picked up. Sends the experience value and performs the base pickup behavior.
    /// </summary>
    public override void BePickUp()
    {
        SendExpValue();
        base.BePickUp();
    }

    /// <summary>
    /// Sends the experience value to the player level manager to be added to the player's experience points.
    /// </summary>
    protected virtual void SendExpValue()
    {
        int exp_value = expItemProfile.GetExpValue();
        PlayerLevelManager.Instance.AddExp(exp_value);
    }
}
