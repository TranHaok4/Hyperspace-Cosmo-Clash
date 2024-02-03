using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class MeteoriteSelfDamageSender : DamageSender
{
    [SerializeField] protected CircleCollider2D collider2d;
    [SerializeField] protected MeteoriteCtrl meteoriteCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider2D();
        this.LoadMeteoriteCtrl();
    }

    protected virtual void LoadCollider2D()
    {
        if (this.collider2d != null) return;
        this.collider2d = GetComponent<CircleCollider2D>();
        this.collider2d.isTrigger = true;
        Debug.Log(transform.name + "LoadCollider2D", gameObject);
    }
    protected void LoadMeteoriteCtrl()
    {
        if (this.meteoriteCtrl != null) return;
        this.meteoriteCtrl = this.transform.parent.GetComponent<MeteoriteCtrl>();
        Debug.Log(transform.name + "LoadMeteoriteCtrl", gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("da va cham");
        if (collision.gameObject.transform.parent.GetComponent<ShipCtrl>() == null) return;
        SendDamage(collision.gameObject.transform);
        this.meteoriteCtrl.Meteoritedespawn.DespawnObject();
    }
}
