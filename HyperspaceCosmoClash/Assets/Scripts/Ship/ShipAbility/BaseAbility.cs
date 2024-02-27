using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for ship abilities.
/// </summary>
public abstract class BaseAbility : HaroMonoBehaviour
{
    [SerializeField] protected AbilityStatSO abilityStats;

    [SerializeField] protected float delaytimer = 0;

    [SerializeField] protected ShipCtrl shipCtrl;
    public ShipCtrl Shipctrl { get => shipCtrl; }
    protected override void Start()
    {
        NotifySkillCoolDown();
        NotifySkillState();
    }
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

    [SerializeField] protected AbilityState abilitystate;
    public abstract void ActiveSkill();

    public void StartCoolDown()
    {
        delaytimer = abilityStats.CoolDownTimer;
        abilitystate = AbilityState.CoolDown;
        NotifySkillState();
    }

    private void NotifySkillState()
    {
        PlayShipSkillNotificater.Instance.OnChangeSkillState(abilitystate);
    }

    private void NotifySkillCoolDown()
    {
        PlayShipSkillNotificater.Instance.OnChangeSkillCoolDown(delaytimer);
    }

    /// <summary>
    /// Updates the cooldown timer for the ship ability.
    /// </summary>
    public void CoolDowning()
    {
        delaytimer -= Time.deltaTime;
        if(delaytimer<=0)
        {
            delaytimer = 0;
            abilitystate = AbilityState.Ready;
            NotifySkillState();
        }
        NotifySkillCoolDown();
    }
    /// <summary>
    /// Checks if the ability is ready to be used.
    /// </summary>
    /// <returns>True if the ability is ready, false otherwise.</returns>
    public virtual bool CheckAbilityisReady()
    {
        return abilitystate == AbilityState.Ready;
    }
}
public enum AbilityState
{
    Ready = 0,
    CoolDown = 1,
}
