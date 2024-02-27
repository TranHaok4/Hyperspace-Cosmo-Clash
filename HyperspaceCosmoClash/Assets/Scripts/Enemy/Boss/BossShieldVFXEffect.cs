using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a visual effects (VFX) effect for the boss shield.
/// </summary>
public class BossShieldVFXEffect : ObjectSelfVFXEffect
{
    protected override IEnumerator VFXCoroutine()
    {
        throw new System.NotImplementedException();
    }

    [SerializeField] protected ShieldImpactVFXName shieldimpactVFXName;

    /// <summary>
    /// Gets the name of the shield impact VFX.
    /// </summary>
    public ShieldImpactVFXName ShieldimpactVFXName { get => shieldimpactVFXName; }

    /// <summary>
    /// Creates the impact shield VFX at the specified position and rotation.
    /// </summary>
    /// <param name="position">The position to create the VFX at.</param>
    /// <param name="rotation">The rotation of the VFX.</param>
    public virtual void CreateImpactShieldVFX(Vector3 position, Quaternion rotation)
    {
        Transform newVFXprefab = VFXSpawner.Instance.Spawn(shieldimpactVFXName.GetName(), position, rotation);
        newVFXprefab.gameObject.SetActive(true);
    }
}
