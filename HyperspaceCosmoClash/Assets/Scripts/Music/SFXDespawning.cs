using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the despawning of sound effects objects after a certain time delay.
/// </summary>
public class SFXDespawning : DespawningByTime
{
    protected override void OnEnable()
    {
        base.OnEnable();
        this.timeDelay = 5f;
    }
    
    /// <summary>
    /// Despawns the sound effect object by calling the Despawn method of the SFXSpawner instance.
    /// </summary>
    public override void DespawnObject()
    {
        SFXSpawner.Instance.Despawn(gameObject.transform);
    }
}
