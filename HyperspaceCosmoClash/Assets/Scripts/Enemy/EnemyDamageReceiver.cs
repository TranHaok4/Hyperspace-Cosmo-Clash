using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [SerializeField] protected EnemyCtrl enemyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }

    protected void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = this.transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + "LoadEnemyCtrl", gameObject);
    }
    protected override void OnDead()
    {
        enemyCtrl.Enemydespawn?.DespawnObject();
        //CreateExplosionVFX();
        //CreateExplosionSFX();
    }
    public override void Deduct(int damage)
    {
        this.enemyCtrl?.EnemyVFXeffect?.StartVFX();
        base.Deduct(damage);
    }
    //protected virtual void CreateExplosionVFX()
    //{
    //    string fxName = enemyCtrl.EnemyVFXeffect.ExplosionVFXname.ToString(); ;
    //    Vector3 hitPos = transform.position;
    //    Quaternion hitRot = transform.rotation;
    //    Transform fxImpact = VFXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
    //    fxImpact.gameObject.SetActive(true);
    //}
    //protected virtual void CreateExplosionSFX()
    //{
    //    AudioManager.Instance.PlaySound(SoundFXName.enemyExplosion, enemyCtrl.transform.position, enemyCtrl.transform.rotation);
    //}
}
