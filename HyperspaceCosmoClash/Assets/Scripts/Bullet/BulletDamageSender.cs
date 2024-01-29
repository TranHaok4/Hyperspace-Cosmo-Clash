using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : DamageSender
{
    [SerializeField] protected BulletCtrl bulletCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }
    protected virtual void LoadBulletCtrl()
    {
        if (bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log(transform.name + "LoadBulletCtrl", gameObject);
    }
    public override void SendDamage(DamageReceiver damageReceiver)
    {
        base.SendDamage(damageReceiver);
        CreateImpactVFX();
        this.DespawnBullet();
    }
    protected virtual void DespawnBullet()
    {
        this.bulletCtrl.BulletDespawn.DespawnObject();
    }

    protected virtual void CreateImpactVFX()
    {
        string fxName = VFXSpawner.vfxone;
        Vector3 hitPos = transform.position;
        Quaternion hitRot = transform.rotation;
        Transform fxImpact = VFXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
        fxImpact.gameObject.SetActive(true);
    }
}
