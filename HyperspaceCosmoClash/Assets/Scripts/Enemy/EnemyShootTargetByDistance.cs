using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootTargetByDistance : ObjectShooting
{
    [Header("EnemyShootTargetByDistance")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance = Mathf.Infinity;
    [SerializeField] protected float shootDistance = 3f;
    [SerializeField] protected bool isRandomShootDelay = false;
    [SerializeField] protected float minRandomDelay = 0.3f;
    [SerializeField] protected float maxRandomDelay = 1f;


    [Header("Shooting type")]
    [SerializeField] protected ShootingBehaviour shootingBehaviour;
    public virtual void SetTarget(Transform _target)
    {
        this.target = _target;
    }

    protected override bool IsShooting()
    {
        this.distance = Vector3.Distance(transform.position, target.position);
        this.isShooting = this.distance <= this.shootDistance;
        return this.isShooting;
    }
    protected override void Shoot()
    {
        shootingBehaviour.Shoot(this, transform.parent, bullet);
        AudioManager.Instance.PlaySound(SoundFXName.enemyshoot,transform.parent.position,transform.parent.rotation);
        if(isRandomShootDelay)
        {
            shootDelay = Random.Range(minRandomDelay, maxRandomDelay);
        }
    }
}
