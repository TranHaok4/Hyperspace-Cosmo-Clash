using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerShipLevelText : HaroMonoBehaviour
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
    protected override void Start()
    {
        base.Start();
        if(ExpShipPlayerNotificater.Instance!=null)
        {
            ExpShipPlayerNotificater.Instance.updateLevelPlayerShip += UpdateLevel;
        }
    }

    protected virtual void UpdateLevel(int levernumber)
    {
        levelNumberText.text = levernumber.ToString();
    }
}
