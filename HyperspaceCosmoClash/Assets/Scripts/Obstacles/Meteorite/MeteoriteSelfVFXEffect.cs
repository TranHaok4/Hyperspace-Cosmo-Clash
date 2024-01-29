using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSelfVFXEffect : ObjectSelfVFXEffect
{
    [SerializeField] protected MeteoriteCtrl meteoriteCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMeteoriteCtrl();
    }
    protected virtual void LoadMeteoriteCtrl()
    {
        if (this.meteoriteCtrl != null) return;
        this.meteoriteCtrl = this.transform.parent.GetComponent<MeteoriteCtrl>();
        Debug.Log(transform.name + "LoadShipCtrl", gameObject);
    }

    protected override IEnumerator VFXCoroutine()
    {
        throw new System.NotImplementedException();
    }
}
