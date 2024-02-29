using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a class that holds ship abilities.
/// </summary>
public class ShipAbilitiesHolder : HaroMonoBehaviour
{
    [SerializeField] protected ShipCtrl shipCtrl;
    [SerializeField] AbilityStatSO abilityIndex1;

    protected override void Start()
    {
        base.Start();
        abilityIndex1.ResetSkill();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipCtrl();
    }
    protected virtual void LoadShipCtrl()
    {
        if (this.shipCtrl != null) return;
        this.shipCtrl = transform.parent?.GetComponent<ShipCtrl>();
        Debug.Log(transform.name+":LoadShipCtrl", gameObject);
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        InputManager.Instance.OnButtonSkill1Change+=ActiveSkill1;
    }

    protected virtual void ActiveSkill1(int isready)
    {
        if(isready==0) return;
        abilityIndex1.ActiveSkill(shipCtrl);
    }

    /*
    protected virtual void Update()
    {
        NotifySkillCoolDown();
        NotifySkillState();
    }
    

    private void NotifySkillCoolDown()
    {
        PlayShipSkillNotificater.Instance.OnChangeSkillCoolDown(abilityIndex1.CoolDownTimer);
    }
    private void NotifySkillState()
    {
        PlayShipSkillNotificater.Instance.OnChangeSkillState(abilityIndex1.Abilitystate);
    }
    */
}

public enum AbilityState
{
    Ready = 0,
    CoolDown = 1,
}