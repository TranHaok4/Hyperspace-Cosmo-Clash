using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShieldDamageReceiver : DamageReceiver
{
    [SerializeField] protected ShipShieldCtrl shipShieldCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadshipShieldCtrl();
    }
    protected virtual void LoadshipShieldCtrl()
    {
        if (this.shipShieldCtrl != null) return;
        this.shipShieldCtrl = this.transform.parent.GetComponent<ShipShieldCtrl>();
        Debug.Log(transform.name + ":LoadshipShieldCtrl", gameObject);
    }   
    protected override void OnDead()
    {
        shipShieldCtrl.ShipShielddespawn.DespawnObject();
    }
}
