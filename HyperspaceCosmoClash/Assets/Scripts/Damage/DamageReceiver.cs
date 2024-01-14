using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public abstract class DamageReceiver : HaroMonoBehaviour
{
    [Header("DamageReceiver")]
    [SerializeField] protected CircleCollider2D dmgcollider;
    [SerializeField] protected int hp = 1;
    [SerializeField] protected int hpMax = 3;
    [SerializeField] protected bool isDead = false;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.Reborn();
    }
    protected void Reborn()
    {
        this.isDead = false;
        this.hp = this.hpMax;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }
    protected virtual void LoadCollider()
    {
        if (this.dmgcollider != null) return;
        this.dmgcollider = GetComponent<CircleCollider2D>();
        this.dmgcollider.isTrigger = true;

        Debug.Log(transform.name + "LoadCollider", gameObject);
    }
    public virtual void Deduct(int damage)
    {
        if (this.isDead) return;
        this.hp -= damage;
        if (this.hp < 0) this.hp = 0;
        this.CheckIsDead();
    }
    protected virtual bool IsDead()
    {
        return this.hp <= 0;
    }
    protected virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }


    protected abstract void OnDead();
}
