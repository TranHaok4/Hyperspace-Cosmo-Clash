using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICoolDownIcon : BaseUIComponent
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
    public override void SetUpUIlogic()
    {
        PlayShipSkillNotificater.Instance.changeSkillState += UpdateSkillIconColor;
    }
}
