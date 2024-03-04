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
    [SerializeField] AbilityStatSO abilityIndex2;

    public virtual void SetSkill(AbilityStatSO ability1, AbilityStatSO ability2)
    {
        abilityIndex1 = ability1;
        abilityIndex2 = ability2;
    }

    protected override void Awake()
    {
        base.Awake();
        PlayShipSkillNotificater.Instance.skillIcon1=abilityIndex1.SkillIcon;
        PlayShipSkillNotificater.Instance.skillIcon2=abilityIndex2.SkillIcon;
    }
    protected override void Start()
    {
        base.Start();
        abilityIndex1.ResetSkill(1);
        abilityIndex2.ResetSkill(2);
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
        InputManager.Instance.OnButtonSkill2Change+=ActiveSkill2;
    }

    protected virtual void ActiveSkill1(int isready)
    {
        if(isready==0) return;
        abilityIndex1.ActiveSkill(shipCtrl);
    }
    protected virtual void ActiveSkill2(int isready)
    {
        if(isready==0) return;
        abilityIndex2.ActiveSkill(shipCtrl);
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