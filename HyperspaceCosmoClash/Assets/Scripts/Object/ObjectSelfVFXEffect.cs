using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for object self visual effects.
/// </summary>
public abstract class ObjectSelfVFXEffect : HaroMonoBehaviour
{
    [Header("ObjectSelfVFXEffect")]
    [SerializeField] protected Material vfxMaterial;
    [SerializeField] protected float duration;
    [SerializeField] protected Coroutine vfxRoutine;
    [SerializeField] protected ExplosionVFXName explosionVFXName;

    /// <summary>
    /// Gets the explosion visual effects name.
    /// </summary>
    public ExplosionVFXName ExplosionVFXname { get => explosionVFXName; }

    /// <summary>
    /// Starts the visual effects.
    /// </summary>
    
    protected virtual void Start()
    {
        Debug.Log("ObjectSelfVFXEffect:Start", gameObject);
    }
    public virtual void StartVFX()
    {
        if (!this.gameObject.activeSelf) return;
        if(vfxRoutine!=null)
        {
            StopCoroutine(vfxRoutine);
        }
        vfxRoutine = StartCoroutine(VFXCoroutine());    
    }

    /// <summary>
    /// Coroutine for the visual effects.
    /// </summary>
    protected abstract IEnumerator VFXCoroutine();
}
