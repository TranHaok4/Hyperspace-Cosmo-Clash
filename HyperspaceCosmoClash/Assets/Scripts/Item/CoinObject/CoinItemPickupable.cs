using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a pickupable coin item in the game.
/// </summary>
public class CoinItemPickupable : ItemPickupable
{
    [SerializeField] protected CoinItemProfileSO coinItemProfile;

    /// <summary>
    /// Called when the coin item is picked up by the player.
    /// </summary>
    public override void BePickUp()
    {
        SendCoinValue();
        base.BePickUp();
    }

    /// <summary>
    /// Sends the coin value to the CoinManager.
    /// </summary>
    protected virtual void SendCoinValue()
    {
        int coin_value = coinItemProfile.Value;
        CoinManager.Instance.AddCoin(coin_value);
    }
}

