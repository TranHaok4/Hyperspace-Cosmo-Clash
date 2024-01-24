using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHUD : BaseHUD
{
    [SerializeField] protected UICoinValueText uiCoinValueText;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCoinValueText();
    }

    protected virtual void LoadCoinValueText()
    {
        if (this.uiCoinValueText != null) return;
        this.uiCoinValueText = this.GetComponentInChildren<UICoinValueText>();
        Debug.Log(transform.name + "LoadCoinValueText", gameObject);
    }

    protected override void Awake()
    {
        StartCoroutine(WaitForConditionThenExecute());
    }
    protected override IEnumerator WaitForConditionThenExecute()
    {
        //Debug.Log("0k");

        while (CoinNotificater.Instance == null)
        {
            yield return null;
        }
        uiCoinValueText.SetUpUIlogic();
    }
    
}
