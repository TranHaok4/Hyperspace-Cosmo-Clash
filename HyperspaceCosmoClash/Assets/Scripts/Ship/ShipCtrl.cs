using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCtrl : HaroMonoBehaviour
{
    [SerializeField] protected ShipDespawn shipDespawn;
    public ShipDespawn Shipdespawn { get => shipDespawn; }
    [SerializeField] protected ShipMovement shipMovement;
    public ShipMovement Shipmovement { get => shipMovement; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipDespawn();
        this.LoadShipMovement();
    }

    protected virtual void LoadShipMovement()
    {
        if (shipMovement != null) return;
        shipMovement = this.GetComponentInChildren<ShipMovement>();
        Debug.Log(transform.name + ":LoadShipMovement", gameObject);
    }

    protected virtual void LoadShipDespawn()
    {
        if (shipDespawn != null) return;
        shipDespawn = this.GetComponentInChildren<ShipDespawn>();
        Debug.Log(transform.name + ":LoadShipDespawn", gameObject);
    }
}
