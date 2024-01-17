using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICoolDownIcon : HaroMonoBehaviour
{
    [SerializeField] protected Image skillIcon;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSkillIcon();
    }
    protected virtual void LoadSkillIcon()
    {
        if (this.skillIcon != null) return;
        this.skillIcon = this.GetComponent<Image>();
        Debug.Log(transform.name + ":LoadSkillIcon", gameObject);
    }
    protected override void Start()
    {
        base.Start();
        if (PlayShipSkillNotificater.Instance != null)
        {
            PlayShipSkillNotificater.Instance.changeSkillState += UpdateSkillIconColor;
        }
    }

    protected virtual void UpdateSkillIconColor(AbilityState state)
    {
        if(state==AbilityState.CoolDown)
        {
            skillIcon.color = Color.gray;
        }
        else
        {
            skillIcon.color = Color.white;
        }
    }
}
