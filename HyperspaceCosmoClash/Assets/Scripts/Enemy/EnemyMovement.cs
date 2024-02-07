using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : ObjecMovement
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float distance = 1f;
    [SerializeField] protected float minDistance = 1f;

    protected virtual void FixedUpdate()
    {
        this.Moving();
    }

    protected virtual void Moving()
    {
        this.distance = Vector3.Distance(transform.parent.position, this.targetPosition);
        if (this.distance < this.minDistance) return;

        Vector3 newpos = Vector3.Lerp(transform.parent.position, targetPosition, this.speed*Time.deltaTime);
        transform.parent.position = newpos;
        //Debug.Log(transform.parent.position);
    }
}
