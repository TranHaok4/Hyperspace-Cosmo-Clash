using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the behavior of an enemy in the game.
/// </summary>
public class EnemyCtrl : HaroMonoBehaviour
{
    [SerializeField] protected EnemyDespawn enemydespawn;
    public EnemyDespawn Enemydespawn { get => enemydespawn; }

    [SerializeField] protected SpriteRenderer model;
    public SpriteRenderer Model { get => model; }

    [SerializeField] protected EnemySelfVFXEffect enemyVFXEffect;
    public EnemySelfVFXEffect EnemyVFXeffect { get => enemyVFXEffect; }

    [SerializeField] protected EnemyDropItem enemyDropItem;
    public EnemyDropItem EnemyDropitem { get => enemyDropItem; }

    [SerializeField] protected EnemyDamageReceiver enemyDamageReceiver;
    public EnemyDamageReceiver EnemyDamagereceiver { get => enemyDamageReceiver; }
    [SerializeField] protected EnemyMovement enemyMovement;
    public EnemyMovement Enemymovement { get => enemyMovement; }

    [SerializeField] protected HPBarType hpBarType;
    public HPBarType HPBartype { get => hpBarType; }

    [SerializeField] protected EnemyLookAtPlayer enemyLookAtPlayer;
    public EnemyLookAtPlayer EnemyLookatplayer { get => enemyLookAtPlayer; }

    protected override void OnEnable()
    {
        base.OnEnable();
        //Debug.Log(transform.position+" "+Time.time);
    }
    //private void Update()
    //{
    //    if (transform.name != "SuperTurtle")
    //    {
    //        Debug.Log(transform.position+" "+Time.time);
    //    }
    //}
    protected override void LoadComponents()    
    {
        base.LoadComponents();
        this.LoadEnemyDespawn();
        this.LoadModel();
        this.LoadEnemyVFXEffect();
        this.LoadEnemyDropItem();
        this.LoadEnemyDamageReceiver();
        this.LoadEnemyMovement();
        this.LoadEnemyLookAtPlayer();
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
        this.enemyVFXEffect = transform.GetComponentInChildren<EnemySelfVFXEffect>();
        Debug.Log(transform.name + ":LoadEnemyDespawn", gameObject);
    }
    protected virtual void LoadEnemyDropItem()
    {
        if (this.enemyDropItem != null) return;
        this.enemyDropItem = transform.GetComponentInChildren<EnemyDropItem>();
        Debug.Log(transform.name + ":LoadEnemyDropItem", gameObject);
    }
    protected virtual void LoadEnemyDamageReceiver()
    {
        if (this.enemyDamageReceiver != null) return;
        this.enemyDamageReceiver = GetComponentInChildren<EnemyDamageReceiver>();
        Debug.Log(transform.name +"LoadEnemyDamageReceiver",gameObject);
    }
    protected virtual void LoadEnemyMovement()
    {
        if (this.enemyMovement != null) return;
        this.enemyMovement = GetComponentInChildren<EnemyMovement>();
        Debug.Log(transform.name + "LoadEnemyMovement", gameObject);
    }

    protected virtual void LoadEnemyLookAtPlayer()
    {
        if(this.enemyLookAtPlayer!=null) return;
        this.enemyLookAtPlayer = GetComponentInChildren<EnemyLookAtPlayer>();
        Debug.Log(transform.name+"LoadEnemyLookAtPlayer",gameObject);
    }

}
