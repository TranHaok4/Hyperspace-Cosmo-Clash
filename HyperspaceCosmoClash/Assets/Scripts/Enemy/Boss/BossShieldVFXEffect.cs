using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShieldVFXEffect : ObjectSelfVFXEffect
{
    protected override IEnumerator VFXCoroutine()
    {
        throw new System.NotImplementedException();
    }
    [SerializeField] protected ShieldImpactVFXName shieldimpactVFXName;
    public ShieldImpactVFXName ShieldimpactVFXName { get => shieldimpactVFXName; }

    public virtual void CreateImpactShieldVFX(Vector3 position,Quaternion rotation)
    {
        Transform newVFXprefab = VFXSpawner.Instance.Spawn(shieldimpactVFXName.GetName(), position, rotation);
        newVFXprefab.gameObject.SetActive(true);
    }

}
