using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : Despawn
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ":LoadEnemyCtrl", gameObject);
    }
    public override void DespawnObject()
    {
        enemyCtrl.EnemyDropitem.Dropping();
        EnemySpawner.Instance.Despawn(transform.parent);
    }
}
