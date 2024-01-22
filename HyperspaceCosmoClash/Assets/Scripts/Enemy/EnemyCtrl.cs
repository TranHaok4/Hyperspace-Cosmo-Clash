using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : HaroMonoBehaviour
{
    [SerializeField] protected EnemyDespawn enemydespawn;
    public EnemyDespawn Enemydespawn { get => enemydespawn; }

    [SerializeField] protected SpriteRenderer model;
    public SpriteRenderer Model { get => model; }

    [SerializeField] protected EnemyVFXEffect enemyVFXEffect;
    public EnemyVFXEffect EnemyVFXeffect { get => enemyVFXEffect; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyDespawn();
        this.LoadModel();
        this.LoadEnemyVFXEffect();
    }
    protected virtual void LoadEnemyDespawn()
    {
        if (this.enemydespawn != null) return;
        this.enemydespawn = transform.GetComponentInChildren<EnemyDespawn>();
        Debug.Log(transform.name + ":LoadEnemyDespawn", gameObject);
    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.GetComponentInChildren<SpriteRenderer>();
        Debug.Log(transform.name + ":LoadModel", gameObject);
    }

    protected virtual void LoadEnemyVFXEffect()
    {
        if (this.enemyVFXEffect != null) return;
        this.enemyVFXEffect = transform.GetComponentInChildren<EnemyVFXEffect>();
        Debug.Log(transform.name + ":LoadEnemyDespawn", gameObject);
    }
}
