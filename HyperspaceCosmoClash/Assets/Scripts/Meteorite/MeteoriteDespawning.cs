using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteDespawning : DespawningByDistance
{
    public override void DespawnObject()
    {
        MeteoriteSpawner.Instance.Despawn(transform.parent);
    }
}
