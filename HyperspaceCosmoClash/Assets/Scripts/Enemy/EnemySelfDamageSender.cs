using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Represents a component that sends damage to itself when colliding with other objects.
/// </summary>
[RequireComponent(typeof(CircleCollider2D))]
public class EnemySelfDamageSender : DamageSender
{
    [SerializeField] protected CircleCollider2D collider2d;
    [SerializeField] protected EnemyCtrl enemyCtrl;

    /// <summary>
    /// Loads the required components for the EnemySelfDamageSender.
    /// </summary>
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider2D();
        this.LoadEnemyCtrl();
    }

    /// <summary>
    /// Loads the CircleCollider2D component if it is not already assigned.
    /// </summary>
    protected virtual void LoadCollider2D()
    {
        if (this.collider2d != null) return;
        this.collider2d = GetComponent<CircleCollider2D>();
        this.collider2d.isTrigger = true;
        Debug.Log(transform.name + "LoadCollider2D", gameObject);
    }

    /// <summary>
    /// Loads the EnemyCtrl component if it is not already assigned.
    /// </summary>
    protected void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = this.transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + "LoadEnemyCtrl", gameObject);
    }

    /// <summary>
    /// Called when the collider enters a trigger collision.
    /// </summary>
    /// <param name="collision">The collider that triggered the collision.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.GetComponent<ShipDamageReceiver>() == null) return;
        SendDamage(collision.gameObject.transform);
        this.enemyCtrl.Enemydespawn.DespawnObject();
    }
}
    