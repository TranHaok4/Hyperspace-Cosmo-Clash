using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents an enemy movement behavior where the enemy moves forward towards a target position.
/// </summary>
public class EnemyMoveForward : EnemyMovement
{
    [SerializeField] protected EnemyCtrl enemyCtrl;

    [Header("EnemyMoveForward")]
    [SerializeField] protected Transform moveTarget;

    [SerializeField] protected float maxDistanceToTarget = 5f;
    /// <summary>
    /// Loads the required components for the enemy movement.
    /// </summary>
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMoveTarget();
        this.LoadEnemyCtrl();
    }

    /// <summary>
    /// Updates the enemy's movement logic in a fixed time interval.
    /// </summary>
    protected override void FixedUpdate()
    {
        this.GetMoveTargetPos();
        base.FixedUpdate();
    }

    /// <summary>
    /// Loads the move target for the enemy.
    /// </summary>
    protected virtual void LoadMoveTarget()
    {
        if (this.moveTarget != null) return;
        this.moveTarget = transform.Find("MoveTarget");
        Debug.Log(transform.name + ":LoadMoveTarget", gameObject);
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ":LoadEnemyCtrl", gameObject);
    }
    /// <summary>
    /// Retrieves the position of the move target and sets it as the enemy's target position.
    /// </summary>
    protected virtual void GetMoveTargetPos()
    {
        this.targetPosition = moveTarget.position;
        this.targetPosition.z = 0;
    }

    protected override void Moving()
    {
        if(CheckDistance())
        {
            base.Moving();
        }
    }
    protected virtual bool CheckDistance()
    {
        if(Vector3.Distance(transform.position, enemyCtrl.EnemyLookatplayer.TargetPosition) > maxDistanceToTarget)
        {
            return true;
        }
        return false;
    }

}
