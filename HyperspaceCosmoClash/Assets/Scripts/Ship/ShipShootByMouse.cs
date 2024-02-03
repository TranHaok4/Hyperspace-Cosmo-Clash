using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootByMouse : ObjectShooting
{
    [SerializeField] protected ShipCtrl shipCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipCtrl();
    }
    protected virtual void LoadShipCtrl()
    {
        if (this.shipCtrl != null) return;
        this.shipCtrl = transform.parent.GetComponent<ShipCtrl>();
        Debug.Log(transform.name + "LoadShipCtrl", gameObject);
    }
    protected override void Awake()
    {
        base.Awake();
        this.shootDelay = shipCtrl.ShipStat.ShipShootSpeed;
    }
    protected override bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFiring == 1;
        return this.isShooting;
    }

    public virtual void IncreaseShootRate(float value)
    {
        shootDelay -= value;
    }

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
