using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CircleCollider2D))]
public class EnemySelfDamageSender : DamageSender
{
    [SerializeField] protected CircleCollider2D collider2d;
    [SerializeField] protected EnemyCtrl enemyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider2D();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadCollider2D()
    {
        if (this.collider2d != null) return;
        this.collider2d = GetComponent<CircleCollider2D>();
        this.collider2d.isTrigger = true;
        Debug.Log(transform.name + "LoadCollider2D", gameObject);
    }
    protected void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = this.transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + "LoadEnemyCtrl", gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("da va cham");
        if (collision.gameObject.transform.parent.GetComponent<ShipCtrl>() == null) return;
        SendDamage(collision.gameObject.transform);
        this.enemyCtrl.Enemydespawn.DespawnObject();
    }
}
    