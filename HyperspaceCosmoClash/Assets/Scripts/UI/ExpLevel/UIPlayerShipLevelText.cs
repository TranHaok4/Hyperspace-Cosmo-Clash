using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerShipLevelText : BaseUIComponent
{

    [SerializeField] protected Text levelNumberText;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadLevelText();
    }

    protected virtual void LoadLevelText()
    {
        if (this.levelNumberText != null) return;
        this.levelNumberText = this.GetComponent<Text>();
        Debug.Log(transform.name + ":LoadLevelText", gameObject);
    }
    protected virtual void UpdateLevel(int levernumber)
    {
        Debug.Log(levernumber);
        levelNumberText.text = levernumber.ToString();
    }

    public override void SetUpUIlogic()
    {
        LevelExpShipPlayerNotificater.Instance.updateLevelPlayerShip += UpdateLevel;
    }
}
