using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Notificater class for playing ship skill notifications.
/// </summary>
public class PlayShipSkillNotificater : Notificater
{
    private static PlayShipSkillNotificater instance;

    /// <summary>
    /// Gets the singleton instance of the PlayShipSkillNotificater.
    /// </summary>
    public static PlayShipSkillNotificater Instance { get => instance; }

    protected override void Awake()
    {
        if (PlayShipSkillNotificater.instance != null) Debug.LogError("Only 1 PlayShipSkillNotificater allowed to exist");
        PlayShipSkillNotificater.instance = this;
        //Debug.Log("da co PlayShipSkillNotificater");
    }

    public UnityAction<AbilityState> changeSkillState1;
    public UnityAction<float> changeSkillCoolDown1;

    public UnityAction<AbilityState> changeSkillState2;
    public UnityAction<float> changeSkillCoolDown2;

    public Sprite skillIcon1;
    public Sprite skillIcon2;

    /// <summary>
    /// Invokes the changeSkillState event with the specified state.
    /// </summary>
    /// <param name="state">The new ability state.</param>
    public void OnChangeSkillState(AbilityState state,int skillindex)
    {
        if(skillindex==1)
        {
            if (changeSkillState1 != null)
            {
                changeSkillState1(state);
            }
        }
        else if(skillindex==2)
        {
            if (changeSkillState2 != null)
            {
                changeSkillState2(state);
            }
        }

    }

    /// <summary>
    /// Invokes the changeSkillCoolDown event with the specified time.
    /// </summary>
    /// <param name="time">The new cooldown time.</param>
    public void OnChangeSkillCoolDown(float time,int skillindex)
    {
        if(skillindex==1)
        {
            if (changeSkillCoolDown1 != null)
            {
                //Debug.Log("OnChangeSkillCoolDown1"+time);
                changeSkillCoolDown1(time);
            }
        }
        else if(skillindex==2)
        {
            if (changeSkillCoolDown2 != null)
            {
                //Debug.Log("OnChangeSkillCoolDown2"+time);
                changeSkillCoolDown2(time);
            }
        }
    }

    IEnumerator WaitforOnchangeSkillState(AbilityState state)
    {
        while(changeSkillState1==null)
        {
            yield return null;
        }
        changeSkillState1(state);
    }

    IEnumerator WaitOnChangeSkillCoolDown(float time)
    {
        while (changeSkillCoolDown1 == null)
        {
            yield return null;
        }
        changeSkillCoolDown1(time);
    }
}
