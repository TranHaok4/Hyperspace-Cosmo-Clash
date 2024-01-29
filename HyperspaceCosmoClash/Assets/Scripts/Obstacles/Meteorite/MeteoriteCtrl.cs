using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteCtrl : HaroMonoBehaviour
{
    [SerializeField] protected MeteoriteDespawning meteoriteDespawn;
    public MeteoriteDespawning Meteoritedespawn { get => meteoriteDespawn; }

    [SerializeField] protected MeteoriteSelfVFXEffect meteoriteVFXEffect;
    public MeteoriteSelfVFXEffect MeteoriteVFXEffect { get => meteoriteVFXEffect; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMeteoriteDespawn();
        this.LoadMeteoriteVFXEffect();
    }
    protected virtual void LoadMeteoriteDespawn()
    {
        if (this.meteoriteDespawn != null) return;
        this.meteoriteDespawn = transform.GetComponentInChildren<MeteoriteDespawning>();
        Debug.Log(transform.name + ":LoadMeteoriteDespawn", gameObject);
    }
    protected virtual void LoadMeteoriteVFXEffect()
    {
        if (this.meteoriteVFXEffect != null) return;
        this.meteoriteVFXEffect = transform.GetComponentInChildren<MeteoriteSelfVFXEffect>();
        Debug.Log(transform.name + ":LoadMeteoriteVFXEffect", gameObject);
    }
}
