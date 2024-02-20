using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawning : DespawningByDistance
{
    [SerializeField] protected BulletImpactVFXName bulletImpactVFXName;
    public override void DespawnObject()
    {
        BulletSpawner.Instance.Despawn(transform.parent);
        CreateImpactVFX();

    }
    protected virtual void CreateImpactVFX()
    {
        string fxName = bulletImpactVFXName.GetName() ;
        Vector3 hitPos = transform.position;
        Quaternion hitRot = transform.rotation;
        Transform fxImpact = VFXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
        fxImpact.gameObject.SetActive(true);
    }
}
