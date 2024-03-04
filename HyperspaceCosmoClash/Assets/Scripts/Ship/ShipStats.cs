using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents the statistics of a ship.
/// </summary>
public class ShipStats : HaroMonoBehaviour
{
    [SerializeField] protected ShipCtrl shipCtrl;

    [SerializeField] protected ShipProfileSO shipProfile;

    protected override void Awake()
    {
        base.Awake();
        if(ShipProfilesManager.Instance!=null)
        {
            SetStatsForShip();
        }
        else StartCoroutine(WaitForShipProfile());
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadShipCtrl();
    }
    
    protected virtual void LoadShipCtrl()
    {
        if (shipCtrl != null) return;
        shipCtrl = this.transform.GetComponent<ShipCtrl>();
        Debug.Log(transform.name + ":LoadShipCtrl", gameObject);
    }


    protected virtual void SetStatsForShip()
    {
        shipProfile = ShipProfilesManager.Instance.CurrentShipProfile;
        SetHP();
        SetDamage();
        SetMoveSpeed();
        SetShootSpeed();
        SetShipModel();
        SetShootBehaviour();
        SetShipSkill();

    }

    IEnumerator WaitForShipProfile()
    {
        yield return new WaitUntil(() => ShipProfilesManager.Instance != null);
        SetStatsForShip();
    }

    public virtual void SetHP()
    {
        shipCtrl.ShipDamageReceiver.AddHPmax(shipProfile.ShipHealth);
    }

    public virtual void SetDamage()
    {
        shipCtrl.ShipShooter.SetShipDamage(shipProfile.ShipDamage);
    }

    public virtual void SetMoveSpeed()
    {
        shipCtrl.Shipmovement.SetMoveSpeed(shipProfile.ShipSpeed);
    }

    public virtual void SetShootSpeed()
    {
        shipCtrl.ShipShooter.SetShootSpeed(shipProfile.ShipShootRate);
    }

    public virtual void SetShipModel()
    {
        Debug.Log("Setting ship model");
        shipCtrl.ShipModel.sprite=shipProfile.ShipSprite;
    }

    public virtual void SetShootBehaviour()
    {
        shipCtrl.ShipShooter.SetShootBehaviour(shipProfile.ShipShootBehaviour);
        shipCtrl.ShipShooter.SetBulletType(shipProfile.Typebullet);
    }

    public virtual void SetShipSkill()
    {
        shipCtrl.ShipAbilitiesholder.SetSkill(shipProfile.Ability1, shipProfile.Ability2);
    }
}
