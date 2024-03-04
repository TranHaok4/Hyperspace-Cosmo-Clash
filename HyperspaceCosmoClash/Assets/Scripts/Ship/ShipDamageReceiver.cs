using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Represents a damage receiver for a ship.
/// </summary>
public class ShipDamageReceiver : DamageReceiver
{
    [SerializeField] protected ShipCtrl shipCtrl;

    /// <summary>
    /// Called when the object is awakened.
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
    }

    /// <summary>
    /// Called when the object is started.
    /// </summary>
    protected override void Start()
    {
        base.Start();
        this.NotifyHPvalue();
    }

    /// <summary>
    /// Loads the required components for the ship damage receiver.
    /// </summary>
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipCtrl();
    }

    /// <summary>
    /// Loads the ship controller component.
    /// </summary>
    protected void LoadShipCtrl()
    {
        if (this.shipCtrl != null) return;
        this.shipCtrl = this.transform.parent.GetComponent<ShipCtrl>();
        Debug.Log(transform.name + "LoadShipCtrl", gameObject);
    }

    /// <summary>
    /// Called when the ship is dead.
    /// </summary>
    protected override void OnDead()
    {
        this.Reborn();
        this.CreateExplosionVFX();
        this.shipCtrl.Shipdespawn.DespawnObject();
    }

    /// <summary>
    /// Deducts the specified damage from the ship's health.
    /// </summary>
    /// <param name="damage">The amount of damage to deduct.</param>
    public override void Deduct(int damage)
    {
        base.Deduct(damage);
        this.NotifyHPvalue();
    }

    /// <summary>
    /// Increases the maximum health of the ship by the specified value.
    /// </summary>
    /// <param name="value">The value to increase the maximum health by.</param>
    public virtual void AddHPmax(int value)
    {
        this.hpMax += value;
        this.hp += value;
        this.NotifyHPvalue();
    }

    /// <summary>
    /// Creates the explosion visual effects for the ship.
    /// </summary>
    protected virtual void CreateExplosionVFX()
    {
        string fxName = shipCtrl.ShipVFXEffect.ExplosionVFXname.ToString(); ;
        Vector3 hitPos = transform.position;
        Quaternion hitRot = transform.rotation;
        Transform fxImpact = VFXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
        fxImpact.gameObject.SetActive(true);
    }

    /// <summary>
    /// Notifies the HP value to the player ship data.
    /// </summary>
    protected virtual void NotifyHPvalue()
    {
        HPShipPlayerNotificater.Instance?.OnUpdateHPPlayerShipData(hp,hpMax);
    }
}
