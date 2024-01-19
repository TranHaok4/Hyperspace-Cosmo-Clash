using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpItemPickupable : ItemPickupable
{
    [SerializeField] protected ExpItemProfileSO expItemProfile;
    public override void BePickUp()
    {
        SendExpValue();
        base.BePickUp();
    }

    protected virtual void SendExpValue()
    {
        int exp_value = expItemProfile.GetExpValue();
        //Debug.Log(exp_value);
        PlayerLevelManager.Instance.AddExp(exp_value);
    }

}
