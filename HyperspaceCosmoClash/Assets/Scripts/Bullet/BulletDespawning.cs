using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawning : DespawningByDistance
{
    public override void DespawnObject()
    {
        BulletSpawner.Instance.Despawn(transform.parent);
    }
}
