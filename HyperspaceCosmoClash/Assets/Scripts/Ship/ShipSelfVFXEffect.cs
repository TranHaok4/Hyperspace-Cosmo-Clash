using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSelfVFXEffect : ObjectSelfVFXEffect
{
    [Header("ShipSelfVFXEffect")]
    [SerializeField] protected ShipCtrl shipCtrl;
    [SerializeField] protected CommonVFXName levelUpVFX;
    public CommonVFXName LevelUpVFX { get => levelUpVFX; }

    protected override void Start()
    {
        base.Start();
        LevelExpShipPlayerNotificater.Instance.updateLevelPlayerShip += CreateLevelUpVFX;
    }
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

    protected virtual void CreateLevelUpVFX(int temp)
    {
        string fxName = levelUpVFX.ToString() ;
        Vector3 hitPos = transform.position;
        Quaternion hitRot = transform.rotation;
        Transform fxImpact = VFXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
        fxImpact.gameObject.SetActive(true);
        fxImpact.parent = shipCtrl.transform;
    }
    protected override IEnumerator VFXCoroutine()
    {
        throw new System.NotImplementedException();
    }
}
