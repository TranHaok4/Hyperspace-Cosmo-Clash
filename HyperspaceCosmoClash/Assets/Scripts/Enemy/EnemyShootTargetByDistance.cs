using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents an enemy behavior that shoots at a target based on distance.
/// </summary>
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

    /// <summary>
    /// Sets the target for the enemy to shoot at.
    /// </summary>
    /// <param name="_target">The target to shoot at.</param>
    public virtual void SetTarget(Transform _target)
    {
        this.target = _target;
    }

    /// <summary>
    /// Determines if the enemy should start shooting based on the distance to the target.
    /// </summary>
    /// <returns>True if the enemy should start shooting, false otherwise.</returns>
    protected override bool IsShooting()
    {
        this.distance = Vector3.Distance(transform.position, target.position);
        this.isShooting = this.distance <= this.shootDistance;
        return this.isShooting;
    }

    /// <summary>
    /// Performs the shooting action.
    /// </summary>
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
