using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipEnhanceManager : HaroMonoBehaviour
{
    [SerializeField] protected ShipCtrl shipCtrl;
    [SerializeField] protected List<EnhancementDataSO> enhancements;

    protected override void Start()
    {
        base.Start();
        this.InitEnhancement();
    }
    protected virtual void InitEnhancement()
    {
        foreach(EnhancementDataSO enhance in enhancements)
        {
            switch(enhance.EnhanceType)
            {
                case EnhancementType.IncreaseHP:
                    IncreaseHPEnhanceSO hpEnhance = enhance as IncreaseHPEnhanceSO;
                    if(hpEnhance!=null)
                    {
                        hpEnhance.beApplyEnhance += IncreaseShipHP;
                    }
                    break;

                case EnhancementType.IncreaseShootSpeed:
                    IncreaseShootSpeedEnhanceSO shootspeedEnhance = enhance as IncreaseShootSpeedEnhanceSO;
                    if (shootspeedEnhance != null)
                    {
                        shootspeedEnhance.beApplyEnhance += IncreaseShootSpeed;
                    }
                    break;
            }

        }
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

    protected virtual void IncreaseShipHP(int value)
    {
        this.shipCtrl.ShipDamageReceiver.AddHPmax(value);
    }

    protected virtual void IncreaseShootSpeed(float value)
    {
        this.shipCtrl.ShipShooter.IncreaseShootRate(value);
    }


}
