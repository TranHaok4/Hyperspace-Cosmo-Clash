using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpLevelHUD : BaseHUD
{
    [SerializeField] protected UIPlayerShipExpBar uiPlayerShipExpBar;
    [SerializeField] protected UIPlayerShipLevelText uiPlayerShipLevelText;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerShipExpBar();
        this.LoadPlayerShipLevelText();
    }

    protected virtual void LoadPlayerShipExpBar()
    {
        if (this.uiPlayerShipExpBar != null) return;
        this.uiPlayerShipExpBar = this.GetComponentInChildren<UIPlayerShipExpBar>();
        Debug.Log(transform.name + "LoadPlayerShipExpBar", gameObject);
    }
    protected virtual void LoadPlayerShipLevelText()
    {
        if (this.uiPlayerShipLevelText != null) return;
        this.uiPlayerShipLevelText = this.GetComponentInChildren<UIPlayerShipLevelText>();
        Debug.Log(transform.name + "LoadPlayerShipLevelText", gameObject);
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
        uiPlayerShipExpBar.SetUpUIlogic();
        uiPlayerShipLevelText.SetUpUIlogic();

    }
}
