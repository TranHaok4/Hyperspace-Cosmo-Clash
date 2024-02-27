using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Represents a damage receiver for enemy objects.
/// </summary>
public class EnemyDamageReceiver : DamageReceiver
{
    [SerializeField] protected EnemyCtrl enemyCtrl;

    /// <summary>
    /// Event that is triggered when the enemy's HP is updated.
    /// </summary>
    /// <param name="currentHP">The current HP of the enemy.</param>
    /// <param name="maxHP">The maximum HP of the enemy.</param>
    public UnityAction<int, int> updateEnemyHP;

    protected override void OnEnable()
    {
        base.OnEnable();
        if (updateEnemyHP != null) updateEnemyHP(hpMax, hpMax);
    }
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
    /// <summary>
    /// Deducts the specified amount of damage from the enemy's health points.
    /// </summary>
    /// <param name="damage">The amount of damage to deduct.</param>
    public override void Deduct(int damage)
    {
        this.enemyCtrl?.EnemyVFXeffect?.StartVFX();
        base.Deduct(damage);
        if (updateEnemyHP != null) updateEnemyHP(hp, hpMax);

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
