using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDespawn : Despawn
{
    public override void DespawnObject()
    {
        this.transform.parent.transform.position = Vector3.zero;
    }
}
