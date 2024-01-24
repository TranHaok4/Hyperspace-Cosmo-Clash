using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UICoinValueText : BaseUIComponent
{

    [SerializeField] protected Text coinValueNumberText;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCoinValueText();
    }

    protected virtual void LoadCoinValueText()
    {
        if (this.coinValueNumberText != null) return;
        this.coinValueNumberText = this.GetComponent<Text>();
        Debug.Log(transform.name + ":LoadCoinValueText", gameObject);
    }
    protected virtual void UpdateCoinValue(int value)
    {
        //Debug.Log(value);
        coinValueNumberText.text = value.ToString();
    }

    public override void SetUpUIlogic()
    {
        CoinNotificater.Instance.updateCoinValue += UpdateCoinValue;
    }
}
