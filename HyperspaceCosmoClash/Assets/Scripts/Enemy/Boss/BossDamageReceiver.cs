using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamageReceiver : EnemyDamageReceiver
{
    public override void Deduct(int damage)
    {
        this.enemyCtrl?.EnemyVFXeffect?.StartVFX();
        base.Deduct(damage);
        BossStatsNotificater.Instance.OnUpdateBossHP(hp, hpMax);
    }
}
