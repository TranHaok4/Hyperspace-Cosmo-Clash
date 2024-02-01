using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXDespawning : DespawningByTime
{
    protected override void OnEnable()
    {
        base.OnEnable();
        this.timeDelay = 5f;
    }
    public override void DespawnObject()
    {
        SFXSpawner.Instance.Despawn(gameObject.transform);
    }
}
