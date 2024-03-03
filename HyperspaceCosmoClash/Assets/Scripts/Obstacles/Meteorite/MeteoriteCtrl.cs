using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the behavior of a meteorite in the game.
/// </summary>
public class MeteoriteCtrl : HaroMonoBehaviour
{
    [SerializeField] protected MeteoriteDespawning meteoriteDespawn;
    public MeteoriteDespawning Meteoritedespawn { get => meteoriteDespawn; }

    [SerializeField] protected MeteoriteSelfVFXEffect meteoriteVFXEffect;
    public MeteoriteSelfVFXEffect MeteoriteVFXEffect { get => meteoriteVFXEffect; }

    [SerializeField] protected MeteoriteDamageReceiver meteoriteDamageReceiver;
    public MeteoriteDamageReceiver MeteoritedamageReceiver { get => meteoriteDamageReceiver; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMeteoriteDespawn();
        this.LoadMeteoriteVFXEffect();
        this.LoadMeteoriteDamageReceiver();
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
    protected virtual void LoadMeteoriteDamageReceiver()
    {
        if (this.meteoriteDamageReceiver != null) return;
        this.meteoriteDamageReceiver = transform.GetComponentInChildren<MeteoriteDamageReceiver>();
        Debug.Log(transform.name + ":LoadMeteoriteDamageReceiver", gameObject);
    }
}
