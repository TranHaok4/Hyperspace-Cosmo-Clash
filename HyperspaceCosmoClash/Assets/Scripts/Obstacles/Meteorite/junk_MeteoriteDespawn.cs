using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class junk_MeteoriteDespawn : Despawn
{
    public override void DespawnObject()
    {
        MeteoriteSpawner.Instance.Despawn(transform.parent);
    }
}
