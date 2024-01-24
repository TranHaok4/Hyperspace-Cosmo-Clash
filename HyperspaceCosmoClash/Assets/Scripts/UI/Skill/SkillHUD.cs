using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHUD : BaseHUD
{
    [SerializeField] protected UICoolDownIcon uiCoolDownIcon;
    [SerializeField] protected UICoolDownText uiCoolDownText;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCoolDownIcon();
        this.LoadCoolDownText();
    }

    protected virtual void LoadCoolDownIcon()
    {
        if (this.uiCoolDownIcon != null) return;
        this.uiCoolDownIcon = this.GetComponentInChildren<UICoolDownIcon>();
        Debug.Log(transform.name + "LoadCoolDownIcon", gameObject);
    }
    protected virtual void LoadCoolDownText()
    {
        if (this.uiCoolDownText != null) return;
        this.uiCoolDownText = this.GetComponentInChildren<UICoolDownText>();
        Debug.Log(transform.name + "LoadCoolDownText", gameObject);
    }
    protected override void Awake()
    {
        StartCoroutine(WaitForConditionThenExecute());
    }
    protected override IEnumerator WaitForConditionThenExecute()
    {
        //Debug.Log("0k");

        while (PlayShipSkillNotificater.Instance == null)
        {
            yield return null;
        }
        uiCoolDownIcon.SetUpUIlogic();
        uiCoolDownText.SetUpUIlogic();

    }
}
