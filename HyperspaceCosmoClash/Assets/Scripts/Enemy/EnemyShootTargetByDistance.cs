using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootTargetByDistance : ObjectShooting
{
    [Header("EnemyShootTargetByDistance")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance = Mathf.Infinity;
    [SerializeField] protected float shootDistance = 3f;
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
}
