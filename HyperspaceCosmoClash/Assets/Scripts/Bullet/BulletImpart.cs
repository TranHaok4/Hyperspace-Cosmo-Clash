using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BulletImpart : HaroMonoBehaviour
{
    [SerializeField] protected BulletCtrl bulletCtrl;
    public BulletCtrl Bulletctrl { get => bulletCtrl; }

    [Header("BulletImpart")]
    [SerializeField] protected CircleCollider2D _collider;
    [SerializeField] protected Rigidbody2D _rigibody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
        this.LoadCollider();
        this.LoadRigibody();
    }
    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = this.transform.parent.GetComponent<BulletCtrl>();
        Debug.Log(transform.name + "LoadBulletCtrl", gameObject);
    }
    protected virtual void LoadCollider()
    {
        if (this._collider != null) return;
        this._collider = GetComponent<CircleCollider2D>();
        this._collider.isTrigger = true;
        this._collider.radius = 0.2f;
        Debug.Log(transform.name + "LoadCollider", gameObject);
    }
    protected virtual void LoadRigibody()
    {
        if (this._rigibody != null) return;
        this._rigibody = GetComponent<Rigidbody2D>();
        this._rigibody.isKinematic = true;
        Debug.Log(transform.name + "LoadRigibody", gameObject);

    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("dumemay");
        if (other.transform.parent == this.bulletCtrl.Shooter) return;
        this.bulletCtrl.BulletDamagesender.SendDamage(other.transform);
        this.DespawnBullet();
    }

    protected virtual void DespawnBullet()
    {
        this.bulletCtrl.BulletDespawn.DespawnObject();
    }
}
