using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the behavior of the boss enemy.
/// </summary>
public class BossCtrl : EnemyCtrl
{
    /// <summary>
    /// Called when the boss enemy is enabled.
    /// </summary>
    protected override void OnEnable()
    {
        base.OnEnable();
        BossStatsNotificater.Instance.OnUpdateBossState(true);
    }

    /// <summary>
    /// Called when the boss enemy is disabled.
    /// </summary>
    protected override void OnDisable()
    {
        base.OnDisable();
        BossStatsNotificater.Instance.OnUpdateBossState(false);
    }
}
