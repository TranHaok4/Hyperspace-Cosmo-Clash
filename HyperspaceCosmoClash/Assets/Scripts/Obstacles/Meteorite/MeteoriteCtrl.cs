using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteCtrl : HaroMonoBehaviour
{
    [SerializeField] MeteoriteDespawning meteoriteDespawn;
    public MeteoriteDespawning Meteoritedespawn { get => meteoriteDespawn; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMeteoriteDespawn();

    }
    protected virtual void LoadMeteoriteDespawn()
    {
        if (this.meteoriteDespawn != null) return;
        this.meteoriteDespawn = transform.GetComponentInChildren<MeteoriteDespawning>();
        Debug.Log(transform.name + ":LoadMeteoriteDespawn", gameObject);
    }
}
