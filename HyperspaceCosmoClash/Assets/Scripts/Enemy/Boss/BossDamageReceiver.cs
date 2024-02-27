using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a damage receiver for the boss enemy.
/// </summary>
public class BossDamageReceiver : EnemyDamageReceiver
{
    /// <summary>
    /// Deducts the specified amount of damage from the boss enemy's health.
    /// </summary>
    /// <param name="damage">The amount of damage to deduct.</param>
    public override void Deduct(int damage)
    {
        this.enemyCtrl?.EnemyVFXeffect?.StartVFX();
        base.Deduct(damage);
        BossStatsNotificater.Instance.OnUpdateBossHP(hp, hpMax);
    }
}
