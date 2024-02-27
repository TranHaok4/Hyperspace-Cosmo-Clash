using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for making an object look at a target position.
/// </summary>
public class ObjectLookAtTarget : HaroMonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float rotSpeed = 3f;

    /// <summary>
    /// Called every fixed frame-rate frame. Makes the object look at the target.
    /// </summary>
    protected virtual void FixedUpdate()
    {
        this.LootAtTarget();
    }

    /// <summary>
    /// Sets the rotation speed of the object.
    /// </summary>
    /// <param name="speed">The new rotation speed.</param>
    public virtual void SetRotSpeed(float speed)
    {
        this.rotSpeed = speed;
    }

    /// <summary>
    /// Calculates the rotation needed for the object to look at the target and applies it.
    /// </summary>
    protected virtual void LootAtTarget()
    {
        Vector3 diff = this.targetPosition - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        float timeSpeed = this.rotSpeed * Time.fixedDeltaTime;
        Quaternion targetEuler = Quaternion.Euler(0f, 0f, rot_z);
        Quaternion currentEuler = Quaternion.Lerp(transform.parent.rotation, targetEuler, timeSpeed);
        transform.parent.rotation = currentEuler;
    }
}
