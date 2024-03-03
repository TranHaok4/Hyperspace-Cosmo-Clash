using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHUD : BaseHUD
{
    [Header("Skill")]
    [SerializeField] protected List<UICoolDownIcon> uiCoolDownIcons;
    [SerializeField] protected List<UICoolDownText> uiCoolDownTexts;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCoolDownIcons();
        this.LoadCoolDownTexts();
    }

    protected virtual void LoadCoolDownIcons()
    {
        if (this.uiCoolDownIcons != null && this.uiCoolDownIcons.Count > 0) return;
        this.uiCoolDownIcons = new List<UICoolDownIcon>(this.GetComponentsInChildren<UICoolDownIcon>());
        Debug.Log(transform.name + "LoadCoolDownIcons", gameObject);
    }
    protected virtual void LoadCoolDownTexts()
    {
        if (this.uiCoolDownTexts != null && this.uiCoolDownTexts.Count > 0) return;
        this.uiCoolDownTexts = new List<UICoolDownText>(this.GetComponentsInChildren<UICoolDownText>());
        Debug.Log(transform.name + "LoadCoolDownTexts", gameObject);
    }

    protected override void Awake()
    {
        SetUpUILogics();
    }
    protected override IEnumerator WaitForConditionThenExecute()
    {
        while(PlayShipSkillNotificater.Instance==null)
        {
            yield return null;
        }
        //Debug.Log("0k");
        for (int i = 0; i < this.uiCoolDownIcons.Count; i++)
        {
            this.uiCoolDownIcons[i].SetUpUIlogic(i+1);
        }
        for (int i = 0; i < this.uiCoolDownTexts.Count; i++)
        {
            this.uiCoolDownTexts[i].SetUpUIlogic(i+1);
        }
    }
    protected virtual void SetUpUILogics()
    {
        StartCoroutine(WaitForConditionThenExecute());
    }
}
