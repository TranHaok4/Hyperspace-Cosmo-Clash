using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCtrl : EnemyCtrl
{
    protected override void OnEnable()
    {
        base.OnEnable();
        BossStatsNotificater.Instance.OnUpdateBossState(true);
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        BossStatsNotificater.Instance.OnUpdateBossState(false);
    }
}
