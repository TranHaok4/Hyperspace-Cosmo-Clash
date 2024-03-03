using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the despawning behavior of a meteorite object.
/// </summary>
public class MeteoriteDespawning : DespawningByDistance
{
    [SerializeField] protected MeteoriteCtrl meteoriteCtrl;

    /// <summary>
    /// Loads the required components for the meteorite despawning.
    /// </summary>
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMeteoriteCtrl();
    }

    /// <summary>
    /// Loads the MeteoriteCtrl component if it is not already assigned.
    /// </summary>
    protected void LoadMeteoriteCtrl()
    {
        if (this.meteoriteCtrl != null) return;
        this.meteoriteCtrl = this.transform.parent.GetComponent<MeteoriteCtrl>();
        Debug.Log(transform.name + "LoadMeteoriteCtrl", gameObject);
    }

    /// <summary>
    /// Despawns the meteorite object.
    /// </summary>
    public override void DespawnObject()
    {
        //CreateExplosionVFX();
        //CreateExplosionSFX();
        MeteoriteSpawner.Instance.Despawn(transform.parent);
    }

    /// <summary>
    /// Creates the explosion visual effects for the meteorite.
    /// </summary>
    protected virtual void CreateExplosionVFX()
    {
        string fxName = meteoriteCtrl.MeteoriteVFXEffect.ExplosionVFXname.GetName().ToString(); ;
        Vector3 hitPos = transform.position;
        Quaternion hitRot = transform.rotation;
        Transform fxImpact = VFXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
        fxImpact.gameObject.SetActive(true);
    }

    /// <summary>
    /// Creates the explosion sound effects for the meteorite.
    /// </summary>
    protected virtual void CreateExplosionSFX()
    {
        AudioManager.Instance.PlaySound(SoundFXName.meteoriteExplosion, meteoriteCtrl.transform.position, meteoriteCtrl.transform.rotation);
    }
}
