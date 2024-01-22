using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectVFXEffect : HaroMonoBehaviour
{
    [Header("ObjectVFXEffect")]
    [SerializeField] protected Material vfxMaterial;
    [SerializeField] protected float duration;
    [SerializeField] protected Coroutine vfxRoutine;
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
