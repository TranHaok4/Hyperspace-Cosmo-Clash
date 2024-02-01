using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayShipSkillNotificater : Notificater
{
    private static PlayShipSkillNotificater instance;
    public static PlayShipSkillNotificater Instance { get => instance; }
    protected override void Awake()
    {
        if (PlayShipSkillNotificater.instance != null) Debug.LogError("Only 1 PlayShipSkillNotificater allow to exist");
        PlayShipSkillNotificater.instance = this;
        //Debug.Log("da co PlayShipSkillNotificater");
    }

    public UnityAction<AbilityState> changeSkillState;
    public UnityAction<float> changeSkillCoolDown;

    public void OnChangeSkillState(AbilityState state)
    {
        if (changeSkillState != null)
        {
            changeSkillState(state);
        }
        else
        {

        }
    }
    public void OnChangeSkillCoolDown(float time)
    {
        if (changeSkillCoolDown != null)
        {
            changeSkillCoolDown(time);
        }
        else
        {

        }
    }
    IEnumerator WaitforOnchangeSkillState(AbilityState state)
    {
        while(changeSkillState==null)
        {
            yield return null;
        }
        changeSkillState(state);
    }
    IEnumerator WaitOnChangeSkillCoolDown(float time)
    {
        while (changeSkillCoolDown == null)
        {
            yield return null;
        }
        changeSkillCoolDown(time);
    }
}
