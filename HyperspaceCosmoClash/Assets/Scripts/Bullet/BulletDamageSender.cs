using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a class that sends damage to a damage receiver using a bullet.
/// </summary>
public class BulletDamageSender : DamageSender
{
    [SerializeField] protected BulletCtrl bulletCtrl;

    protected override void Start()
    {
        base.Start();
    }
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
    /// <summary>
    /// Sends damage to a damage receiver.
    /// </summary>
    /// <param name="damageReceiver">The damage receiver to send damage to.</param>
    public override void SendDamage(DamageReceiver damageReceiver)
    {
        Debug.Log("BulletDamageSender: SendDamage: " + damageReceiver.gameObject.name, gameObject);
        base.SendDamage(damageReceiver);
        //CreateImpactVFX();
        this.DespawnBullet();
    }
    protected virtual void DespawnBullet()
    {
        this.bulletCtrl.BulletDespawn.DespawnObject();
    }

    //protected virtual void CreateImpactVFX()
    //{
    //    string fxName = VFXSpawner.vfxone;
    //    Vector3 hitPos = transform.position;
    //    Quaternion hitRot = transform.rotation;
    //    Transform fxImpact = VFXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
    //    fxImpact.gameObject.SetActive(true);
    //}
}
