using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : HaroMonoBehaviour
{
    protected virtual void FixedUpdate()
    {
        this.Despawning();
    }
    protected virtual void Despawning()
    {
        if (!this.CanDespawn()) return;
        DespawnObject();
    }
    public virtual void DespawnObject()
    {
        //TO-DO
    }

    protected abstract bool CanDespawn();
}
