using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the despawning of bullets based on distance and creates impact visual effects.
/// </summary>
public class BulletDespawning : DespawningByDistance
{
    [SerializeField] protected BulletImpactVFXName bulletImpactVFXName;

    /// <summary>
    /// Despawns the bullet object and creates the impact visual effect.
    /// </summary>
    public override void DespawnObject()
    {
        //Debug.LogWarning("BulletDespawning: DespawnObject: " + transform.parent.name, transform.parent.gameObject);
        BulletSpawner.Instance.Despawn(transform.parent);
        CreateImpactVFX();
    }

    /// <summary>
    /// Creates the impact visual effect at the bullet's position and rotation.
    /// </summary>
    protected virtual void CreateImpactVFX()
    {
        string fxName = bulletImpactVFXName.GetName();
        Vector3 hitPos = transform.position;
        Quaternion hitRot = transform.rotation;
        Transform fxImpact = VFXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
        fxImpact.gameObject.SetActive(true);
    }
}
