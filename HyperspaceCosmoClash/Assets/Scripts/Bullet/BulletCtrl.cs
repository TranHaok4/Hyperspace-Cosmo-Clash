using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the behavior of a bullet in the game.
/// </summary>
public class BulletCtrl : HaroMonoBehaviour
{
    [SerializeField] protected bool isChangeName=true;

    [SerializeField] protected BulletDespawning bulletDespawn;
    public BulletDespawning BulletDespawn { get => bulletDespawn; }

    [SerializeField] protected BulletDamageSender bulletDamageSender;
    public BulletDamageSender BulletDamagesender { get => bulletDamageSender; }

    [SerializeField] protected Transform shooter;
    public Transform Shooter { get => shooter; }

    [SerializeField] protected TypeBullet bulletName;

    private void OnValidate()
    {
        if(isChangeName==false) return;
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
    /// <summary>
    /// Sets the shooter of the bullet.
    /// </summary>
    /// <param name="shooter">The transform of the shooter.</param>
    public virtual void SetShooter(Transform shooter)
    {
        this.shooter = shooter;
    }

}

/// <summary>
/// Represents the type of a bullet.
/// </summary>
public enum TypeBullet
{
    none = 0,
    RedPlayerBullet = 1,
    RedBulletNormalEnemyBullet = 2,
    CircleRedEnemyBullet=3,
    SuperTurleBullet=4,
    GreenPlayerBullet = 5,

}