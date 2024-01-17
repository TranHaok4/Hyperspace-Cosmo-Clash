using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UICoolDownText : HaroMonoBehaviour
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
    protected override void Start()
    {
        base.Start();
        if(PlayShipSkillNotificater.Instance!=null)
        {
            PlayShipSkillNotificater.Instance.changeSkillCoolDown += UpdateSkillcooldownText ;
        }
    }

    protected virtual void UpdateSkillcooldownText(float time)
    {
        cooldownSkillText.text = time.ToString("F2");
        if (time <= 0) cooldownSkillText.text = "";
    }
}
