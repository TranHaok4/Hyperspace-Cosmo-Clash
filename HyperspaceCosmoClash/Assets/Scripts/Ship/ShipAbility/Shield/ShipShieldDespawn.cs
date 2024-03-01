using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShieldDespawn : Despawn
{
    public System.Action onShieldDespawnCallBack;

    public override void DespawnObject()
    {
        base.DespawnObject();
        onShieldDespawnCallBack?.Invoke();
        Destroy(this.transform.parent.gameObject);
    }
}
