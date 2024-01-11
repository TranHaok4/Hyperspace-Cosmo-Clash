using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public abstract class ItemPickupable : HaroMonoBehaviour
{
    [Header("ItemPickupale")]
    [SerializeField] protected CircleCollider2D _collider;
    [SerializeField] protected ItemCtrl itemCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadItemCtrl();
    }
    protected virtual void LoadItemCtrl()
    {
        if (this.itemCtrl != null) return;
        this.itemCtrl = this.transform.parent.GetComponent<ItemCtrl>();
        Debug.Log(transform.name + ":LoadItemCtrl", gameObject);
    }
    protected virtual void LoadCollider()
    {
        if (this._collider != null) return;
        this._collider = transform.GetComponent<CircleCollider2D>();
        this._collider.isTrigger = true;
        Debug.Log(transform.name + ":LoadCollider", gameObject);
    }

    public virtual void BePickUp()
    {
        this.itemCtrl.Itemdespawn.DespawnObject();
    }
}
