using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipDamageReceiver : DamageReceiver
{
    [SerializeField] protected ShipCtrl shipCtrl;

    protected override void Awake()
    {
        base.Awake();
        this.hpMax = shipCtrl.ShipStat.ShipHeath;
    }
    protected override void Start()
    {
        base.Start();
        this.NotifyHPvalue();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipCtrl();
    }

    protected void LoadShipCtrl()
    {
        if (this.shipCtrl != null) return;
        this.shipCtrl = this.transform.parent.GetComponent<ShipCtrl>();
        Debug.Log(transform.name + "LoadShipCtrl", gameObject);
    }
    protected override void OnDead()
    {
        this.Reborn();
        this.CreateExplosionVFX();
        this.shipCtrl.Shipdespawn.DespawnObject();
    }
    public override void Deduct(int damage)
    {
        base.Deduct(damage);
        this.NotifyHPvalue();
    }

    public virtual void AddHPmax(int value)
    {
        this.hpMax += value;
        this.hp += value;
        this.NotifyHPvalue();
    }

    protected virtual void CreateExplosionVFX()
    {
        string fxName = shipCtrl.ShipVFXEffect.ExplosionVFXname.ToString(); ;
        Vector3 hitPos = transform.position;
        Quaternion hitRot = transform.rotation;
        Transform fxImpact = VFXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
        fxImpact.gameObject.SetActive(true);
    }
    protected virtual void NotifyHPvalue()
    {
        //Debug.Log("notify hp");
        HPShipPlayerNotificater.Instance.OnUpdateHPPlayerShipData(hp,hpMax);
    }
}
