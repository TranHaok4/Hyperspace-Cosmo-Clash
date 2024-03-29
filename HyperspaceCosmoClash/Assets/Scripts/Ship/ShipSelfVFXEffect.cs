using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a visual effects effect for the ship itself.
/// </summary>
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

    /// <summary>
    /// Creates a visual effects (VFX) for the ship's level up event.
    /// </summary>
    /// <param name="temp">The temporary value used for the VFX creation.</param>
    protected virtual void CreateLevelUpVFX(int temp)
    {
        string fxName = levelUpVFX.GetName().ToString() ;
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
