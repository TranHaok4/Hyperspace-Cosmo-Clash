using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhancementHUD : BaseHUD
{
    [SerializeField] protected UIEnhancementPanel uiEnhancementPanel;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnhancementPanel();
    }

    protected virtual void LoadEnhancementPanel()
    {
        if (this.uiEnhancementPanel != null) return;
        this.uiEnhancementPanel = this.GetComponentInChildren<UIEnhancementPanel>();
        Debug.Log(transform.name + "LoadEnhancementPanel", gameObject);
    }

    protected override void Awake()
    {
        StartCoroutine(WaitForConditionThenExecute());
    }
    protected override IEnumerator WaitForConditionThenExecute()
    {
        //Debug.Log("0k");

        while (LevelExpShipPlayerNotificater.Instance == null)
        {
            yield return null;
        }
        uiEnhancementPanel.SetUpUIlogic();
    }
}
