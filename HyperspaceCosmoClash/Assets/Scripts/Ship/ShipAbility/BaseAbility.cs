using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAbility : HaroMonoBehaviour
{
    [SerializeField] protected AbilityStatSO abilityStats;

    [SerializeField] protected float delaytimer = 0;

    [SerializeField] protected ShipCtrl shipCtrl;
    public ShipCtrl Shipctrl { get => shipCtrl; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipCtrl();
    }
    protected void LoadShipCtrl()
    {
        if (this.shipCtrl != null) return;
        this.shipCtrl = transform.parent.parent?.GetComponent<ShipCtrl>();
        Debug.Log(transform.name+":LoadShipCtrl", gameObject);
    }

    protected enum AbilityState
    {
        Ready = 0,
        CoolDown = 1,
    }
    [SerializeField] protected AbilityState abilitystate;
    public abstract void ActiveSkill();

    public void StartCoolDown()
    {
        delaytimer = abilityStats.CoolDownTimer;
        abilitystate = AbilityState.CoolDown;
    }
    public void CoolDowning()
    {
        delaytimer -= Time.deltaTime;
        if(delaytimer<=0)
        {
            delaytimer = 0;
            abilitystate = AbilityState.Ready;
        }
    }
    public virtual bool CheckAbilityisReady()
    {
        return abilitystate == AbilityState.Ready;
    }
}

