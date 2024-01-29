using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSelfVFXEffect : ObjectSelfVFXEffect
{
    [SerializeField] protected ShipCtrl shipCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipCtrl();
    }
    protected virtual void LoadShipCtrl()
    {
        if (this.shipCtrl != null) return;
        this.shipCtrl = this.transform.parent.GetComponent<ShipCtrl>();
        Debug.Log(transform.name + "LoadShipCtrl", gameObject);
    }

    protected override IEnumerator VFXCoroutine()
    {
        throw new System.NotImplementedException();
    }
}
