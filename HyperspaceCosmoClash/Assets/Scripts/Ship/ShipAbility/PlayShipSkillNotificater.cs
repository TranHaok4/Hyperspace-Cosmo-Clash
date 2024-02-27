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

    public UnityAction<AbilityState> changeSkillState;
    public UnityAction<float> changeSkillCoolDown;

    /// <summary>
    /// Invokes the changeSkillState event with the specified state.
    /// </summary>
    /// <param name="state">The new ability state.</param>
    public void OnChangeSkillState(AbilityState state)
    {
        if (changeSkillState != null)
        {
            changeSkillState(state);
        }
        else
        {
            // Handle the case when changeSkillState is null
        }
    }

    /// <summary>
    /// Invokes the changeSkillCoolDown event with the specified time.
    /// </summary>
    /// <param name="time">The new cooldown time.</param>
    public void OnChangeSkillCoolDown(float time)
    {
        if (changeSkillCoolDown != null)
        {
            changeSkillCoolDown(time);
        }
        else
        {
            // Handle the case when changeSkillCoolDown is null
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
