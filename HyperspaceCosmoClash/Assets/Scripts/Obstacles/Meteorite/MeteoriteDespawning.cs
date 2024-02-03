using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteDespawning : DespawningByDistance
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
    public override void DespawnObject()
    {
        CreateExplosionVFX();
        CreateExplosionSFX();
        MeteoriteSpawner.Instance.Despawn(transform.parent);
    }

    protected virtual void CreateExplosionVFX()
    {
        string fxName = meteoriteCtrl.MeteoriteVFXEffect.ExplosionVFXname.ToString(); ;
        Vector3 hitPos = transform.position;
        Quaternion hitRot = transform.rotation;
        Transform fxImpact = VFXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
        fxImpact.gameObject.SetActive(true);
    }
    protected virtual void CreateExplosionSFX()
    {
        AudioManager.Instance.PlaySound(SoundFXName.meteoriteExplosion, meteoriteCtrl.transform.position, meteoriteCtrl.transform.rotation);
    }
}
