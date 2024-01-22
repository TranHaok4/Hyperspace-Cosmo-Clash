using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVFXEffect : ObjectVFXEffect
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected Material originalMaterial;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
        this.LoadOrigninalMaterial();
    }
    protected virtual void LoadOrigninalMaterial()
    {
        this.originalMaterial = this.enemyCtrl.Model.material;
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.enemyCtrl.Model.material = originalMaterial;
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = this.transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + "LoadEnemyCtrl", gameObject);
    }

    protected override IEnumerator VFXCoroutine()
    {
        this.enemyCtrl.Model.material = vfxMaterial;
        yield return new WaitForSeconds(duration);
        this.enemyCtrl.Model.material = originalMaterial;
    }
}
