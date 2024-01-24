using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStatHUD : BaseHUD
{
    [SerializeField] protected UIPlayerShipHPBar uiPlayerShipHPBar;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerShipHPBar();
    }

    protected virtual void LoadPlayerShipHPBar()
    {
        if (this.uiPlayerShipHPBar != null) return;
        this.uiPlayerShipHPBar = this.GetComponentInChildren<UIPlayerShipHPBar>();
        Debug.Log(transform.name + "LoadPlayerShipHPBar", gameObject);
    }
    protected override void Awake()
    {
        StartCoroutine(WaitForConditionThenExecute());
    }
    protected override IEnumerator WaitForConditionThenExecute()
    {
        //Debug.Log("0k");

        while (HPShipPlayerNotificater.Instance == null)
        {
            yield return null;
        }
        uiPlayerShipHPBar.SetUpUIlogic();

    }
}
