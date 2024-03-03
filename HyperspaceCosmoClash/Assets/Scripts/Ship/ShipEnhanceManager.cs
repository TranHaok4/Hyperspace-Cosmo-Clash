using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the enhancements for a ship.
/// </summary>
public class ShipEnhanceManager : HaroMonoBehaviour
{
    [SerializeField] protected ShipCtrl shipCtrl;
    [SerializeField] protected List<EnhancementDataSO> enhancements;

    /// <summary>
    /// Initializes the ship enhancements.
    /// </summary>
    protected override void Start()
    {
        base.Start();
        this.InitEnhancement();
    }

    /// <summary>
    /// Initializes each enhancement and assigns the corresponding event handlers.
    /// </summary>
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
                case EnhancementType.IncreaseDamage:
                    IncreaseDamageEnhanceSO damageEnhance = enhance as IncreaseDamageEnhanceSO;
                    if (damageEnhance != null)
                    {
                        damageEnhance.beApplyEnhance += IncreaseShipDamage;
                    }
                    break;
            }

        }
    }

    /// <summary>
    /// Loads the required components.
    /// </summary>
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipCtrl();
    }

    /// <summary>
    /// Loads the ShipCtrl component if it is not already loaded.
    /// </summary>
    protected void LoadShipCtrl()
    {
        if (this.shipCtrl != null) return;
        this.shipCtrl = this.transform.parent.GetComponent<ShipCtrl>();
        Debug.Log(transform.name + "LoadShipCtrl", gameObject);
    }

    /// <summary>
    /// Increases the ship's maximum HP by the specified value.
    /// </summary>
    /// <param name="value">The value to increase the HP by.</param>
    protected virtual void IncreaseShipHP(int value)
    {
        this.shipCtrl.ShipDamageReceiver.AddHPmax(value);
    }

    /// <summary>
    /// Increases the ship's shoot speed by the specified value.
    /// </summary>
    /// <param name="value">The value to increase the shoot speed by.</param>
    protected virtual void IncreaseShootSpeed(float value)
    {
        this.shipCtrl.ShipShooter.IncreaseShootRate(value);
    }

    /// <summary>
    /// Increases the ship's damage by the specified value.
    /// </summary>
    /// <param name="value">The value to increase the damage by.</param>
    protected virtual void IncreaseShipDamage(int value)
    {
        this.shipCtrl.ShipStat.IncreaseShipDamage(value);
    }
}
