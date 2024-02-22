using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectSelfVFXEffect : HaroMonoBehaviour
{
    [Header("ObjectSelfVFXEffect")]
    [SerializeField] protected Material vfxMaterial;
    [SerializeField] protected float duration;
    [SerializeField] protected Coroutine vfxRoutine;
    [SerializeField] protected ExplosionVFXName explosionVFXName;
    public ExplosionVFXName ExplosionVFXname { get => explosionVFXName; }

    public virtual void StartVFX()
    {

        if (!this.gameObject.activeSelf) return;
        if(vfxRoutine!=null)
        {
            StopCoroutine(vfxRoutine);
        }
        vfxRoutine = StartCoroutine(VFXCoroutine());    
    }
    protected abstract IEnumerator VFXCoroutine();
}
