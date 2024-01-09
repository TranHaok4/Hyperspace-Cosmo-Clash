using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
