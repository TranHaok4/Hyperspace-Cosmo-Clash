using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the behavior and functionality of a ship in the game.
/// </summary>
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

    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D RB { get => rb; }

    [SerializeField] protected ShipStats shipStats;
    public ShipStats ShipStat { get => shipStats; }

    [SerializeField] protected ShipSelfVFXEffect shipVFXEffect;
    public ShipSelfVFXEffect ShipVFXEffect { get => shipVFXEffect; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipDespawn();
        this.LoadShipMovement();
        this.LoadShipDamageReceiver();
        this.LoadShipShooter();
        this.LoadRigibody2D();
        this.LoadShipStats();
        this.LoadShipVFXEffect();
    }
    protected virtual void LoadRigibody2D()
    {
        if (this.rb != null) return;
        this.rb = this.GetComponent<Rigidbody2D>();
        this.rb.freezeRotation = true;
        Debug.Log(transform.name + ":LoadRigibody2D", gameObject);
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
    protected virtual void LoadShipStats()
    {
        if (shipStats != null) return;
        shipStats = this.GetComponent<ShipStats>();
        Debug.Log(transform.name + ":LoadShipStats", gameObject);
    }
    protected virtual void LoadShipVFXEffect()
    {
        if (shipVFXEffect != null) return;
        shipVFXEffect = this.GetComponentInChildren<ShipSelfVFXEffect>();
        Debug.Log(transform.name + ":LoadShipVFXEffect", gameObject);
    }
}
