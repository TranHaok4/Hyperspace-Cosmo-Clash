using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDespawn : Despawn
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ":LoadEnemyCtrl", gameObject);
    }

    public System.Action OnDespawmObjectCallBack;
    public override void DespawnObject()
    {
        Debug.Log("Despawn");
        enemyCtrl.EnemyDropitem?.Dropping();
        EnemySpawner.Instance.Despawn(transform.parent);
        CreateExplosionVFX();
        CreateExplosionSFX();
        OnDespawmObjectCallBack?.Invoke();
    }
    protected virtual void CreateExplosionVFX()
    {
        string fxName = enemyCtrl.EnemyVFXeffect?.ExplosionVFXname.ToString(); ;
        if (fxName == null) return;
        Vector3 hitPos = transform.position;
        Quaternion hitRot = transform.rotation;
        Transform fxImpact = VFXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
        fxImpact.gameObject.SetActive(true);
    }
    protected virtual void CreateExplosionSFX()
    {
        AudioManager.Instance.PlaySound(SoundFXName.enemyExplosion, enemyCtrl.transform.position, enemyCtrl.transform.rotation);
    }
}
