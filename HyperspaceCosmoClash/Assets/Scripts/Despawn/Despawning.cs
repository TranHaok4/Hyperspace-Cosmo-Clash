using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawning : Despawn
{
    protected void FixedUpdate()
    {
        this.DespawningLoop();
    }
    protected virtual void DespawningLoop()
    {
        if (!this.CanDespawn()) return;
        DespawnObject();
    }
    protected abstract bool CanDespawn();
}
