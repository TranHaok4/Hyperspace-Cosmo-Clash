using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerShipExpBar : HaroMonoBehaviour
{
    protected override void Start()
    {
        base.Start();
        if (ExpShipPlayerNotificater.Instance != null)
        {
            //Debug.Log("add action");
            ExpShipPlayerNotificater.Instance.UpdateExpPlayerShip += UpdateExpBar;
        }
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
        Debug.Log("UpdateExpBar:"+currentExp+" "+maxExp);
        this.shipExpBar.value = (float)currentExp / maxExp;
    }
}
