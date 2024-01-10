using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipDamageReceiver : DamageReceiver
{
    [SerializeField] protected ShipCtrl shipCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipCtrl();
    }

    protected void LoadShipCtrl()
    {
        if (this.shipCtrl != null) return;
        this.shipCtrl = this.transform.parent.GetComponent<ShipCtrl>();
        Debug.Log(transform.name + "LoadShipCtrl", gameObject);
    }
    protected override void OnDead()
    {
        this.Reborn();
        this.shipCtrl.Shipdespawn.DespawnObject();
    }
}
