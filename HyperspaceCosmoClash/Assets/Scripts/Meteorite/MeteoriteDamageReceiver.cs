using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteDamageReceiver : DamageReceiver
{
    [SerializeField] protected MeteoriteCtrl meteoriteCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMeteoriteCtrl();
    }

    protected void LoadMeteoriteCtrl()
    {
        if (this.meteoriteCtrl != null) return;
        this.meteoriteCtrl = this.transform.parent.GetComponent<MeteoriteCtrl>();
        Debug.Log(transform.name + "LoadMeteoriteCtrl", gameObject);
    }
    protected override void OnDead()
    {
        meteoriteCtrl.Meteoritedespawn.DespawnObject();
    }
}
