using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveForward : EnemyMovement
{
    [Header("EnemyMoveForward")]
    [SerializeField] protected Transform moveTarget;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMoveTarget();
    }

    protected override void FixedUpdate()
    {
        this.GetMoveTargetPos();
        base.FixedUpdate();

    }
    protected virtual void LoadMoveTarget()
    {
        if (this.moveTarget != null) return;
        this.moveTarget = transform.Find("MoveTarget");
        Debug.Log(transform.name + ":LoadMoveTarget", gameObject);
    }
    protected virtual void GetMoveTargetPos()
    {
        this.targetPosition = moveTarget.position;
        this.targetPosition.z = 0;
    }
}
