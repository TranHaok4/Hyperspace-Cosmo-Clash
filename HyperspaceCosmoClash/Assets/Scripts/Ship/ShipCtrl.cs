using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCtrl : HaroMonoBehaviour
{
    [SerializeField] protected ShipDespawn shipDespawn;
    public ShipDespawn Shipdespawn { get => shipDespawn; }
    [SerializeField] protected ShipMovement shipMovement;
    public ShipMovement Shipmovement { get => shipMovement; }

    [SerializeField] protected ShipDamageReceiver shipDamageReceiver;
    public ShipDamageReceiver ShipDamageReceiver { get => shipDamageReceiver; }

    [SerializeField] protected ShipShootByMouse shipShooter;
    public ShipShootByMouse ShipShooter { get => shipShooter; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipDespawn();
        this.LoadShipMovement();
        this.LoadShipDamageReceiver();
        this.LoadShipShooter();
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
    protected virtual void LoadShipDamageReceiver()
    {
        if (shipDamageReceiver != null) return;
        shipDamageReceiver = this.GetComponentInChildren<ShipDamageReceiver>();
        Debug.Log(transform.name + ":LoadShipDamageReceiver", gameObject);
    }
    protected virtual void LoadShipShooter()
    {
        if (shipShooter != null) return;
        shipShooter = this.GetComponentInChildren<ShipShootByMouse>();
        Debug.Log(transform.name + ":LoadShipShooter", gameObject);
    }
}
