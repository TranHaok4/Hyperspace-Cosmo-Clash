using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component that allows an object to despawn after a certain amount of time.
/// </summary>
public class DespawningByTime : Despawning
{
    [Header("DespawningByTime")]
    [SerializeField] protected float timeDelay = 0.1f;
    [SerializeField] protected float timer = 0f;

    /// <summary>
    /// Determines whether the object can be despawned based on the elapsed time.
    /// </summary>
    /// <returns>True if the object can be despawned, false otherwise.</returns>
    protected override bool CanDespawn()
    {
        timer += Time.deltaTime;
        if(timer >= timeDelay)
        {
            timer = 0;
            return true;
        }
        return false;
    }
}
