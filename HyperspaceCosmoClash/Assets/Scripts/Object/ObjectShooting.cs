using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectShooting : HaroMonoBehaviour
{
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
    protected void Shooting()
    {
        this.shootTimer += Time.fixedDeltaTime;
        if (!this.isShooting) return;
        if (this.shootTimer <= this.shootDelay) return;
        this.shootTimer = 0;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne, spawnPos, rotation);
        if (newBullet == null) return;

        newBullet.gameObject.SetActive(true);
    }

    protected abstract bool IsShooting();
}
