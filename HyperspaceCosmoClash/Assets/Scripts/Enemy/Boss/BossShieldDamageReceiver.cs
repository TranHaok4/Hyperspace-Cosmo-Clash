using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a component responsible for receiving damage to the boss shield.
/// </summary>
public class BossShieldDamageReceiver : EnemyDamageReceiver
{
    [SerializeField] protected BossShieldCtrl bossShieldCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBossShieldCtrl();
    }

    protected virtual void LoadBossShieldCtrl()
    {
        if (this.bossShieldCtrl != null) return;
        this.bossShieldCtrl = transform.parent.GetComponent<BossShieldCtrl>();
        Debug.Log(transform.name + "LoadBossShieldCtrl", gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 collisionPos = collision.transform.position;
        Quaternion collisionRot = collision.transform.rotation;
        bossShieldCtrl.BossShieldVFX.CreateImpactShieldVFX(collisionPos, collisionRot);
    }
}
