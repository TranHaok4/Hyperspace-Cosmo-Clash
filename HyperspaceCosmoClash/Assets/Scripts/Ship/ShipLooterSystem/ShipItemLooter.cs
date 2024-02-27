using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class represents a ship item looter, which is responsible for picking up items when the ship collides with them.
/// </summary>
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class ShipItemLooter : HaroMonoBehaviour
{
    [SerializeField] protected CircleCollider2D _collider;
    [SerializeField] protected Rigidbody2D _rigibody;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigibody();
    }
    protected virtual void LoadCollider()
    {
        if (this._collider != null) return;
        this._collider = transform.GetComponent<CircleCollider2D>();
        this._collider.isTrigger = true;
        Debug.Log(transform.name + ":LoadCollider", gameObject);
    }
    protected virtual void LoadRigibody()
    {
        if (this._rigibody != null) return;
        this._rigibody = transform.GetComponent<Rigidbody2D>();
        this._rigibody.isKinematic = true;
        Debug.Log(transform.name + ":LoadRigibody", gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ItemPickupable itempickupable = collider.GetComponent<ItemPickupable>();
        if (itempickupable == null) return;
        //Debug.Log("ok den day");
        itempickupable.BePickUp();
    }
}
