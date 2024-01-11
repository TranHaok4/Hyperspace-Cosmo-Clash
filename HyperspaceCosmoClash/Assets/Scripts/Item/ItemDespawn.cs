using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDespawn : Despawn
{
    public override void DespawnObject()
    {
        ItemSpawner.Instance.Despawn(transform.parent);
    }
}
