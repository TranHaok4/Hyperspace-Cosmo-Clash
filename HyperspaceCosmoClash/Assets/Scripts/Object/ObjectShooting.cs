using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectShooting : HaroMonoBehaviour
{
    [SerializeField] protected TypeBullet bullet;

    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 0.2f;
    [SerializeField] protected float shootTimer = 0f;

    protected void Update()
    {
        this.IsShooting();
    }
    protected void FixedUpdate()
    {
        this.Shooting();
    }
    

    protected virtual void Shooting()
    {
        this.shootTimer += Time.fixedDeltaTime;
        if (!this.isShooting) return;
        if (this.shootTimer <= this.shootDelay) return;
        this.shootTimer = 0;
        this.Shoot();
    }
    protected virtual void Shoot()
    {
        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(bullet.ToString(), spawnPos, rotation);
        if (newBullet == null) return;
        newBullet.GetComponent<BulletCtrl>().SetShooter(this.transform.parent);
        newBullet.gameObject.SetActive(true);
    }
    protected abstract bool IsShooting();
}

public enum TypeBullet
{
    none=0,
    PlayerBullet=1,
    EnemyBullet=2,
}