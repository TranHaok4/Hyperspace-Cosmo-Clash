using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UICoolDownText : BaseUIComponent
{
    [SerializeField] protected Text cooldownSkillText;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCooldownText();
    }

    protected virtual void LoadCooldownText()
    {
        if (this.cooldownSkillText != null) return;
        this.cooldownSkillText = this.GetComponent<Text>();
        Debug.Log(transform.name + ":LoadLevelText", gameObject);
    }

    protected virtual void UpdateSkillcooldownText(float time)
    {
        cooldownSkillText.text = time.ToString("F2");
        if (time <= 0) cooldownSkillText.text = "";
    }
    public override void SetUpUIlogic()
    {
        // Add your implementation for SetUpUIlogic here
    }
    public virtual void SetUpUIlogic(int index)
    {
        if(index==1)
        {
            PlayShipSkillNotificater.Instance.changeSkillCoolDown1 += UpdateSkillcooldownText;
        }
        else if(index==2)
        {
            PlayShipSkillNotificater.Instance.changeSkillCoolDown2 += UpdateSkillcooldownText;
        }
    }
}
