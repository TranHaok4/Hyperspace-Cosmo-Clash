using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : HaroMonoBehaviour
{
    [SerializeField] protected BulletDespawning bulletDespawn;
    public BulletDespawning BulletDespawn { get => bulletDespawn; }

    [SerializeField] protected BulletDamageSender bulletDamageSender;
    public BulletDamageSender BulletDamagesender { get => bulletDamageSender; }

    [SerializeField] protected Transform shooter;
    public Transform Shooter { get => shooter; }

    [SerializeField] protected TypeBullet bulletName;

    private void OnValidate()
    {
        transform.name = bulletName.ToString();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletDespawn();
        this.LoadBulletDamageSender();
    }
    protected virtual void LoadBulletDespawn()
    {
        if (bulletDespawn != null) return;
        bulletDespawn = GetComponentInChildren<BulletDespawning>();
        Debug.Log(transform.name + "LoadBulletDespawn", gameObject);
    }
    protected virtual void LoadBulletDamageSender()
    {
        if (bulletDamageSender != null) return;
        bulletDamageSender = GetComponentInChildren<BulletDamageSender>();
        Debug.Log(transform.name + "BulletDamageSender", gameObject);
    }
    public virtual void SetShooter(Transform shooter)
    {
        this.shooter = shooter;
    }

}

public enum TypeBullet
{
    none = 0,
    PlayerBullet = 1,
    RedBulletNormalEnemyBullet = 2,
    CircleRedEnemyBullet=3,
    SuperTurleBullet=4,
}