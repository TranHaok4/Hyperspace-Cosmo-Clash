using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
/// <summary>
/// Base abstract class for items components when it is picked
/// </summary>
public abstract class ItemPickupable : HaroMonoBehaviour
{
    [Header("ItemPickupale")]
    [SerializeField] protected CircleCollider2D _collider;
    [SerializeField] protected ItemCtrl itemCtrl;

    /// <summary>
    /// Loads the required components for the ItemPickupable.
    /// </summary>
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadItemCtrl();
    }

    /// <summary>
    /// Loads the ItemCtrl component if it is not already assigned.
    /// </summary>
    protected virtual void LoadItemCtrl()
    {
        if (this.itemCtrl != null) return;
        this.itemCtrl = this.transform.parent.GetComponent<ItemCtrl>();
        Debug.Log(transform.name + ":LoadItemCtrl", gameObject);
    }

    /// <summary>
    /// Loads the CircleCollider2D component if it is not already assigned.
    /// </summary>
    protected virtual void LoadCollider()
    {
        if (this._collider != null) return;
        this._collider = transform.GetComponent<CircleCollider2D>();
        this._collider.isTrigger = true;
        Debug.Log(transform.name + ":LoadCollider", gameObject);
    }

    /// <summary>
    /// Called when the item is picked up.
    /// </summary>
    public virtual void BePickUp()
    {
        this.itemCtrl.Itemdespawn.DespawnObject();
    }
}
