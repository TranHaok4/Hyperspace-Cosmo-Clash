using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesDamageSender : DamageSender
{
    [SerializeField] protected ObstaclesCtrl obstacleCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObstacleCtrl();
    }
    protected virtual void LoadObstacleCtrl()
    {
        if (this.obstacleCtrl != null) return;
        this.obstacleCtrl = transform.parent.GetComponent<ObstaclesCtrl>();
        Debug.Log(transform.name + "LoadObstacleCtrl", gameObject);
    }
    public override void SendDamage(DamageReceiver damageReceiver)
    {
        base.SendDamage(damageReceiver);
    }
}
