using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class allows an object to follow a target by smoothly interpolating its position towards the target's position.
/// </summary>
public class FollowTarget : HaroMonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 2f;

    protected virtual void FixedUpdate()
    {
        this.Following();
    }

    protected virtual void Following()
    {
        if (this.target == null) return;
        transform.position = Vector3.Lerp(this.transform.position, target.position, Time.fixedDeltaTime * speed);
    }

    /// <summary>
    /// Sets the target for the object to follow.
    /// </summary>
    /// <param name="_target">The transform of the target object.</param>
    public virtual void SetTarget(Transform _target)
    {
        target = _target;
    }
}
