using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayShipSkillNotificater : HaroMonoBehaviour
{
    private static PlayShipSkillNotificater instance;
    public static PlayShipSkillNotificater Instance { get => instance; }
    protected override void Awake()
    {
        base.Awake();
        if (PlayShipSkillNotificater.instance != null) Debug.LogError("Only 1 PlayShipSkillNotificater allow to exist");
        PlayShipSkillNotificater.instance = this;
        Debug.Log("da co ExpShipPlayerManager");
    }

    public UnityAction<AbilityState> changeSkillState;
    public UnityAction<float> changeSkillCoolDown;

    public void OnChangeSkillState(AbilityState state)
    {
        if (changeSkillState == null) return;

        changeSkillState(state );
    }
    public void OnChangeSkillCoolDown(float time)
    {
        if (changeSkillCoolDown == null) return;

        changeSkillCoolDown(time);
    }

}
