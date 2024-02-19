using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShieldCtrl : EnemyCtrl
{
    [SerializeField] protected BossShieldVFXEffect bossShieldVFX;
    public BossShieldVFXEffect BossShieldVFX { get => bossShieldVFX; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBossShieldVFX();
    }
    protected virtual void LoadBossShieldVFX()
    {
        if (this.bossShieldVFX != null) return;
        this.bossShieldVFX = GetComponentInChildren<BossShieldVFXEffect>();
        Debug.Log(transform.name + "LoadBossShieldVFX", gameObject);
    }
}
