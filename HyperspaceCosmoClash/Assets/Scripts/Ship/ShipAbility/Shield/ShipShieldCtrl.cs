using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShieldCtrl : HaroMonoBehaviour
{
    [SerializeField] protected ShipShieldDamageReceiver shipShieldDamageReceiver;
    public ShipShieldDamageReceiver ShipShielddamageReceiver { get => this.shipShieldDamageReceiver; }

    [SerializeField] protected ShipShieldDespawn shipShieldDespawn;
    public ShipShieldDespawn ShipShielddespawn { get => this.shipShieldDespawn; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadShipShieldDamageReceiver();
        LoadShipShieldDespawn();
    }
    protected virtual void LoadShipShieldDamageReceiver()
    {
        if (this.shipShieldDamageReceiver != null) return;
        this.shipShieldDamageReceiver = this.GetComponentInChildren<ShipShieldDamageReceiver>();
        Debug.Log(transform.name + ":LoadShipShieldDamageReceiver", gameObject);
    }
    protected virtual void LoadShipShieldDespawn()
    {
        if (this.shipShieldDespawn != null) return;
        this.shipShieldDespawn = this.GetComponentInChildren<ShipShieldDespawn>();
        Debug.Log(transform.name + ":LoadShipShieldDespawn", gameObject);
    }
}
