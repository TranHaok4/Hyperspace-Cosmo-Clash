using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component attached to a meteorite object that sends damage to other game objects upon collision with a ship.
/// </summary>
[RequireComponent(typeof(CircleCollider2D))]
public class MeteoriteSelfDamageSender : DamageSender
{
    [SerializeField] protected CircleCollider2D collider2d;
    [SerializeField] protected MeteoriteCtrl meteoriteCtrl;

    /// <summary>
    /// Loads the required components for the meteorite self damage sender.
    /// </summary>
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider2D();
        this.LoadMeteoriteCtrl();
    }

    /// <summary>
    /// Loads the CircleCollider2D component and configures it as a trigger.
    /// </summary>
    protected virtual void LoadCollider2D()
    {
        if (this.collider2d != null) return;
        this.collider2d = GetComponent<CircleCollider2D>();
        this.collider2d.isTrigger = true;
        Debug.Log(transform.name + "LoadCollider2D", gameObject);
    }

    /// <summary>
    /// Loads the MeteoriteCtrl component from the parent object.
    /// </summary>
    protected void LoadMeteoriteCtrl()
    {
        if (this.meteoriteCtrl != null) return;
        this.meteoriteCtrl = this.transform.parent.GetComponent<MeteoriteCtrl>();
        Debug.Log(transform.name + "LoadMeteoriteCtrl", gameObject);
    }

    /// <summary>
    /// Called when the meteorite collider triggers a collision with another collider.
    /// </summary>
    /// <param name="collision">The collider that the meteorite collided with.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.parent.GetComponent<ShipCtrl>() == null) return;
        SendDamage(collision.gameObject.transform);
        this.meteoriteCtrl.Meteoritedespawn.DespawnObject();
    }
}
