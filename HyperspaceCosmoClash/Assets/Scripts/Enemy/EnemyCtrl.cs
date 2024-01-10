using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : HaroMonoBehaviour
{
    [SerializeField] EnemyDespawn enemydespawn;
    public EnemyDespawn Enemydespawn { get => enemydespawn; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyDespawn();

    }
    protected virtual void LoadEnemyDespawn()
    {
        if (this.enemydespawn != null) return;
        this.enemydespawn = transform.GetComponentInChildren<EnemyDespawn>();
        Debug.Log(transform.name + ":LoadEnemyDespawn", gameObject);
    }
}
