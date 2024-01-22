using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXDespawning : DespawningByTime
{
    public override void DespawnObject()
    {
        VFXSpawner.Instance.Despawn(transform.parent);
    }
}
