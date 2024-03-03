using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a class responsible for despawning a ship object.
/// </summary>
public class ShipDespawn : Despawn
{
    /// <summary>
    /// Despawns the ship object by resetting its parent's position to Vector3.zero.
    /// </summary>
    public override void DespawnObject()
    {
        this.transform.parent.transform.position = Vector3.zero;
    }
}
