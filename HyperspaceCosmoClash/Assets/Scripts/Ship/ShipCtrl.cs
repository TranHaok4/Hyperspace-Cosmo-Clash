using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCtrl : HaroMonoBehaviour
{
    [SerializeField] protected ShipDespawn shipDespawn;
    public ShipDespawn Shipdespawn { get => shipDespawn; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipDespawn();
    }
    protected virtual void LoadShipDespawn()
    {
        if (shipDespawn != null) return;
        shipDespawn = this.GetComponentInChildren<ShipDespawn>();
        Debug.Log(transform.name + ":LoadShipDespawn", gameObject);
    }
}
