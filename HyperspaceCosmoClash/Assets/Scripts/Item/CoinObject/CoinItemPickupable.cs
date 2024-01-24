using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItemPickupable : ItemPickupable
{
    [SerializeField] protected CoinItemProfileSO coinItemProfile;
    public override void BePickUp()
    {
        SendCoinValue();
        base.BePickUp();
    }

    protected virtual void SendCoinValue()
    {
        int coin_value = coinItemProfile.Value;
        //Debug.Log(exp_value);
        CoinManager.Instance.AddCoin(coin_value);
    }
}

