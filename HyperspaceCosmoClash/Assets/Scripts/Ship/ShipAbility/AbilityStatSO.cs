using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a ScriptableObject that holds the statistics for a ship ability.
/// </summary>
public abstract class AbilityStatSO : ScriptableObject
{


    [SerializeField] protected float coolDownDelay;
    public float CoolDownDelay { get => coolDownDelay; }


    /// <summary>
    /// The cooldown timer for the ability.
    /// </summary>
    [SerializeField] protected float coolDownTimer;
    public float CoolDownTimer { get => coolDownTimer; }

    [SerializeField] protected AbilityState abilityState=AbilityState.Ready;
    public AbilityState Abilitystate { get => abilityState; }

    [SerializeField] protected string skillName;

    public virtual void ResetSkill()
    {
        abilityState = AbilityState.Ready;
        coolDownTimer = 0;
        NotifySkillState();
        NotifySkillCoolDown();
    }

    public abstract void ActiveSkill(ShipCtrl shipCtrl);

    protected IEnumerator Cooldowning()
    {
        coolDownTimer = coolDownDelay;
        abilityState = AbilityState.CoolDown;
        NotifySkillState();
        while(coolDownTimer>=0)
        {
            coolDownTimer -= Time.deltaTime;
            NotifySkillCoolDown();
            yield return null;
        }
        abilityState = AbilityState.Ready;
        NotifySkillState();
    }
    private void NotifySkillCoolDown()
    {
            PlayShipSkillNotificater.Instance.OnChangeSkillCoolDown(CoolDownTimer);
    }
    private void NotifySkillState()
    {
        PlayShipSkillNotificater.Instance.OnChangeSkillState(Abilitystate);
    }

}
