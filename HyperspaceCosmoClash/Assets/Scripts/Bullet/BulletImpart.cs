using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Represents a component that imparts behavior to a bullet object.
/// </summary>
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BulletImpart : HaroMonoBehaviour
{
    [SerializeField] protected BulletCtrl bulletCtrl;
    public BulletCtrl Bulletctrl { get => bulletCtrl; }

    [Header("BulletImpart")]
    [SerializeField] protected CircleCollider2D _collider;
    [SerializeField] protected Rigidbody2D _rigibody;

    /// <summary>
    /// Loads the required components for the BulletImpart class.
    /// </summary>
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
        this.LoadCollider();
        this.LoadRigibody();
    }

    /// <summary>
    /// Loads the BulletCtrl component if it is not already assigned.
    /// </summary>
    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = this.transform.parent.GetComponent<BulletCtrl>();
        Debug.Log(transform.name + "LoadBulletCtrl", gameObject);
    }

    /// <summary>
    /// Loads the CircleCollider2D component if it is not already assigned.
    /// </summary>
    protected virtual void LoadCollider()
    {
        if (this._collider != null) return;
        this._collider = GetComponent<CircleCollider2D>();
        this._collider.isTrigger = true;
        this._collider.radius = 0.2f;
        Debug.Log(transform.name + "LoadCollider", gameObject);
    }

    /// <summary>
    /// Loads the Rigidbody2D component if it is not already assigned.
    /// </summary>
    protected virtual void LoadRigibody()
    {
        if (this._rigibody != null) return;
        this._rigibody = GetComponent<Rigidbody2D>();
        this._rigibody.isKinematic = true;
        Debug.Log(transform.name + "LoadRigibody", gameObject);
    }

    /// <summary>
    /// Called when the collider attached to this object collides with another collider.
    /// </summary>
    /// <param name="other">The other collider involved in the collision.</param>
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent == this.bulletCtrl.Shooter) return;
        this.bulletCtrl.BulletDamagesender.SendDamage(other.transform);
    }
}
