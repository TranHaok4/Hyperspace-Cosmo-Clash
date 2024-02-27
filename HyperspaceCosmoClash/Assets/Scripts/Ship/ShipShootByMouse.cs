using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a class that handles shooting behavior for a ship controlled by mouse input.
/// </summary>
public class ShipShootByMouse : ObjectShooting
{
    [SerializeField] protected ShipCtrl shipCtrl;

    /// <summary>
    /// Loads the required components for shooting and the ship control.
    /// </summary>
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipCtrl();
    }

    /// <summary>
    /// Loads the ship control component if it is not already assigned.
    /// </summary>
    protected virtual void LoadShipCtrl()
    {
        if (this.shipCtrl != null) return;
        this.shipCtrl = transform.parent.GetComponent<ShipCtrl>();
        Debug.Log(transform.name + "LoadShipCtrl", gameObject);
    }

    /// <summary>
    /// Initializes the shooting delay based on the ship's shoot speed.
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
        this.shootDelay = shipCtrl.ShipStat.ShipShootSpeed;
    }

    /// <summary>
    /// Determines if the ship is currently shooting based on the input.
    /// </summary>
    /// <returns>True if the ship is shooting, false otherwise.</returns>
    protected override bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFiring == 1;
        return this.isShooting;
    }

    /// <summary>
    /// Increases the shoot rate of the ship by the specified value.
    /// </summary>
    /// <param name="value">The value by which to increase the shoot rate.</param>
    public virtual void IncreaseShootRate(float value)
    {
        shootDelay -= value;
    }

    /// <summary>
    /// Spawns a bullet and sets its properties based on the ship's stats.
    /// </summary>
    protected override void Shoot()
    {
        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(bullet.ToString(), spawnPos, rotation);
        if (newBullet == null) return;
        newBullet.GetComponent<BulletCtrl>().SetShooter(this.transform.parent);
        newBullet.gameObject.SetActive(true);
        newBullet.GetComponent<BulletCtrl>().BulletDamagesender.ChangeDamage(shipCtrl.ShipStat.ShipDamage);

        AudioManager.Instance.PlaySound(SoundFXName.playershoot, shipCtrl.transform.position, shipCtrl.transform.rotation);
    }
}
