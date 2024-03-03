using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a class responsible for despawning a meteorite object.
/// </summary>
public class junk_MeteoriteDespawn : Despawn
{
    /// <summary>
    /// Despawns the meteorite object by calling the Despawn method of the MeteoriteSpawner instance.
    /// </summary>
    public override void DespawnObject()
    {
        MeteoriteSpawner.Instance.Despawn(transform.parent);
    }
}
