using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerShipExpBar : BaseUIComponent
{
    protected override void Awake()
    {
        StartCoroutine(WaitForConditionThenExecute());
    }
    protected override IEnumerator WaitForConditionThenExecute()
    {

        while (LevelExpShipPlayerNotificater.Instance == null)
        {
            yield return null;
        }
        Debug.Log("0k");
        LevelExpShipPlayerNotificater.Instance.updateExpPlayerShip += UpdateExpBar;
    }

    [SerializeField] protected Slider shipExpBar;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipExpBar();

    }
    protected virtual void LoadShipExpBar()
    {
        if (this.shipExpBar != null) return;
        this.shipExpBar = this.GetComponent<Slider>();
        Debug.Log(transform.name + ":LoadShipExpBar", gameObject);
    }
    protected virtual void UpdateExpBar(int currentExp, int maxExp)
    {
        //Debug.Log("haha");
        //Debug.Log("UpdateExpBar:"+currentExp+" "+maxExp);
        this.shipExpBar.value = (float)currentExp / maxExp;
    }
}
