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
        CreateExplosionVFX();
        meteoriteCtrl.Meteoritedespawn.DespawnObject();
    }
    protected virtual void CreateExplosionVFX()
    {
        string fxName = meteoriteCtrl.MeteoriteVFXEffect.ExplosionVFXname.ToString(); ;
        Vector3 hitPos = transform.position;
        Quaternion hitRot = transform.rotation;
        Transform fxImpact = VFXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
        fxImpact.gameObject.SetActive(true);
    }
}
